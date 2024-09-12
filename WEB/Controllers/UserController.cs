using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Service;

namespace WEB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _service;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly MailService _mailService;
        public UserController(UserService userService, IMapper mapper, RoleManager<Role> roleManager, RoleService roleService, UserManager<User> userManager, MailService mailService)
        {
            _service = userService;
            _mapper = mapper;
            _roleManager = roleManager;
            _roleService = roleService;
            _userManager = userManager;
            _mailService = mailService;
        }
        /*public async Task<IActionResult> MailExample()
        {
          await _mailService.SendMessageAsync("icoban94@gmail.com", "örnek mail","bu bir örnek maildir.");
            return Ok();
        }*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _service.GetUserListAsync();
            if (users == null)
                return BadRequest();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var userList = await _service.GetAllAsync();
            var userListDto = _mapper.Map<List<UserDto>>(userList.ToList());

            return View(CustomResponseDto<List<UserDto>>.Success(200, userListDto));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var roleAllList = await _roleService.GetAllAsync();
            var roleList = _mapper.Map<List<RoleDto>>(roleAllList.Where(x => !x.IsDeleted));

            ViewBag.Roles = new SelectList(roleList, "Id", "Name");

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            var roleAllList = await _roleService.GetAllAsync();
            var roleList = _mapper.Map<List<RoleDto>>(roleAllList.Where(x => !x.IsDeleted));
            ViewBag.Roles = new SelectList(roleList, "Id", "Name");

            var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor. Lütfen başka bir e-posta adresi girin.");
                return View(userDto);
            }

            var user = _mapper.Map<User>(userDto);
            user.UserVerifyState = "Beklemede";

            var createResult = await _userManager.CreateAsync(user);

            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userDto);
            }

            user.UserName = user.Email;//1
            var roleResult = await _roleService.GetAsync(x => x.Id == userDto.RoleId);

            if (roleResult == null)
            {
                ModelState.AddModelError("", "Rol bulunamadı.");
                return View(userDto);
            }

            var roleAddResult = await _userManager.AddToRoleAsync(user, roleResult.Name);

            if (!roleAddResult.Succeeded)
            {
                foreach (var error in roleAddResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userDto);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordLink = Url.Action("UserVerifyPage", "User", new { userId = user.Id, token }, Request.Scheme);
            await _mailService.SendMessageAsync(user.Email, "BEYCELİK / KayıpTakip", $"Lütfen şifrenizi sıfırlamak için <a href='{resetPasswordLink}'>buraya tıklayın</a>.");

            //user.UserVerifyState = "Onaylandı";
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserVerifyPage(Guid userId, string token, string Email)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return NotFound();

            ViewBag.Token = token;

            return View(user);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserVerifyPage(Guid id, string token, string newPassword, string confirmPassword)
        {
            if (!newPassword.Equals(confirmPassword))
            {
                ModelState.AddModelError("", "Şifreler uyuşmuyor.");
                return View();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View();
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (resetPassResult.Succeeded)
            {
                await _mailService.SendMessageAsync(user.Email, "BEYCELİK / KayıpTakip", "Tebrikler! Şifreniz başarı ile oluşturuldu.");
                user.UserVerifyState = "Onaylandı";
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }

            foreach (var error in resetPassResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _service.GetAsync(x => x.Id == id, "UserRoles,UserRoles.Role");
            var roleAllList = await _roleService.GetAllAsync();

            var roleList = _mapper.Map<List<RoleDto>>(roleAllList.Where(x => !x.IsDeleted));

            if (user.UserRoles.Any())
            {
                var userRole = user.UserRoles.First().RoleId;

                ViewData["RoleId"] = new SelectList(roleList, "Id", "Name", userRole);

                var mapperRole = _mapper.Map<UserDto>(user);
                mapperRole.RoleId = userRole;

                return View(mapperRole);
            }

            ViewData["RoleId"] = new SelectList(roleList, "Id", "Name");

            var mapper = _mapper.Map<UserDto>(user);

            return View(mapper);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(UserDto userListDto)
        {
            var user = await _userManager.FindByIdAsync(userListDto.Id.ToString());
            if (user == null)
            {
                return NotFound($"User with ID {userListDto.Id} not found.");
            }

            user.Name = userListDto.Name;
            user.SurName = userListDto.SurName;
            user.UserName = userListDto.UserName;
            user.Email = userListDto.Email;
            user.NormalizedEmail = userListDto.NormalizedEmail.ToUpper();

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userListDto);
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeRoleResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeRoleResult.Succeeded)
                {
                    ModelState.AddModelError("", "Mevcut rollerden çıkarma işlemi başarısız oldu.");
                    return View(userListDto);
                }
            }

            var newRole = await _roleManager.FindByIdAsync(userListDto.RoleId.ToString());
            if (newRole == null)
            {
                return NotFound($"Role with ID {userListDto.RoleId} not found.");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, newRole.Name);
            if (!addRoleResult.Succeeded)
            {
                ModelState.AddModelError("", "Yeni rol ekleme işlemi başarısız oldu.");
                return View(userListDto);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ShowUser(Guid id)
        {
            var user = await _service.GetAsync(x => x.Id == id, "UserRoles,UserRoles.Role");
            var roleAllList = await _roleService.GetAllAsync();

            var roleList = _mapper.Map<List<RoleDto>>(roleAllList.Where(x => !x.IsDeleted));

            if (user.UserRoles.Any())
            {
                var userRole = user.UserRoles.First().RoleId;

                ViewData["RoleId"] = new SelectList(roleList, "Id", "Name", userRole);

                var mapperRole = _mapper.Map<UserDto>(user);
                mapperRole.RoleId = userRole;

                return View(mapperRole);
            }

            ViewData["RoleId"] = new SelectList(roleList, "Id", "Name");

            var mapper = _mapper.Map<UserDto>(user);

            return View(mapper);
        }


        [HttpPost]
        public async Task<IActionResult> ShowUser(UserDto userListDto)
        {
            var user = await _userManager.FindByIdAsync(userListDto.Id.ToString());
            if (user == null)
            {
                return NotFound($"User with ID {userListDto.Id} not found.");
            }

            user.Name = userListDto.Name;
            user.SurName = userListDto.SurName;
            user.UserName = userListDto.UserName;
            user.Email = userListDto.Email;
            user.NormalizedEmail = userListDto.NormalizedEmail.ToUpper();

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userListDto);
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeRoleResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeRoleResult.Succeeded)
                {
                    ModelState.AddModelError("", "Mevcut rollerden çıkarma işlemi başarısız oldu.");
                    return View(userListDto);
                }
            }

            var newRole = await _roleManager.FindByIdAsync(userListDto.RoleId.ToString());
            if (newRole == null)
            {
                return NotFound($"Role with ID {userListDto.RoleId} not found.");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, newRole.Name);
            if (!addRoleResult.Succeeded)
            {
                ModelState.AddModelError("", "Yeni rol ekleme işlemi başarısız oldu.");
                return View(userListDto);
            }

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _service.GetAsync(x => x.Id == id, "UserRoles,UserRoles.Role");
            var roleAllList = await _roleService.GetAllAsync();

            var roleList = _mapper.Map<List<RoleDto>>(roleAllList.Where(x => !x.IsDeleted));

            if (user.UserRoles.Any())
            {
                var userRole = user.UserRoles.First().RoleId;

                ViewData["RoleId"] = new SelectList(roleList, "Id", "Name", userRole);

                var mapperRole = _mapper.Map<UserDto>(user);
                mapperRole.RoleId = userRole;

                return View(mapperRole);
            }

            ViewData["RoleId"] = new SelectList(roleList, "Id", "Name");

            var mapper = _mapper.Map<UserDto>(user);

            return View(mapper);
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserDto userListDto)
        {
            var user = await _userManager.FindByIdAsync(userListDto.Id.ToString());
            if (user == null)
            {
                return NotFound($"User with ID {userListDto.Id} not found.");
            }

            user.Name = userListDto.Name;
            user.SurName = userListDto.SurName;
            user.UserName = userListDto.UserName;
            user.Email = userListDto.Email;
            user.NormalizedEmail = userListDto.NormalizedEmail.ToUpper();

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userListDto);
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeRoleResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeRoleResult.Succeeded)
                {
                    ModelState.AddModelError("", "Mevcut rollerden çıkarma işlemi başarısız oldu.");
                    return View(userListDto);
                }
            }

            var newRole = await _roleManager.FindByIdAsync(userListDto.RoleId.ToString());
            if (newRole == null)
            {
                return NotFound($"Role with ID {userListDto.RoleId} not found.");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, newRole.Name);
            if (!addRoleResult.Succeeded)
            {
                ModelState.AddModelError("", "Yeni rol ekleme işlemi başarısız oldu.");
                return View(userListDto);
            }

            return RedirectToAction(nameof(Index));


        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var userList = await _service.GetByIdAsync(id);
            userList.IsDeleted = true;
            await _service.UpdateAsync(userList);
            return RedirectToAction(nameof(Index));
        }

    }
}
