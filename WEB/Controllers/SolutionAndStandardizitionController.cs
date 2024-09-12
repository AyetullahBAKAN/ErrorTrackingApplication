using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class SolutionAndStandardizitionController : Controller
    {
        private readonly SolutionAndStandardizitonService _service;
        private readonly ErrorClosingReasonService _errorClosingReasonService;
        private readonly IMapper _mapper;
        public SolutionAndStandardizitionController(SolutionAndStandardizitonService service, IMapper mapper, ErrorClosingReasonService errorClosingReasonService)
        {
            _service = service;
            _mapper = mapper;
            _errorClosingReasonService = errorClosingReasonService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetSolutionandStandardizitionListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var solutionAndStandardizitions = await _service.GetAllAsync();
            var solutionAndStandardizitionsDto = _mapper.Map<List<SolutionAndStandardizitionDto>>(solutionAndStandardizitions.ToList());

            return View(CustomResponseDto<List<SolutionAndStandardizitionDto>>.Success(200, solutionAndStandardizitionsDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorClosingReasons = await _errorClosingReasonService.GetAllAsync();
            var errorClosingReasonDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReasons.Where(x => !x.IsDeleted));
            ViewBag.errorClosingReasons = new SelectList(errorClosingReasonDto, "Id", "Reason");
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(SolutionAndStandardizitionDto solutionAndStandardizitionsDto)
        {

            var solutionAndStandardizition = await _service.AddAsync(_mapper.Map<SolutionAndStandardizition>(solutionAndStandardizitionsDto));
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var solutionList = await _service.GetByIdAsync(id);

            var errorClosingReasons = await _errorClosingReasonService.GetAllAsync();

            var errorClosingReasonDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReasons.Where(x => !x.IsDeleted));
            ViewBag.errorClosingReasons = new SelectList(errorClosingReasonDto, "Id", "Reason", solutionList.ErrorClosingReasonId);


            return View(_mapper.Map<SolutionAndStandardizitionDto>(solutionList));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(SolutionAndStandardizitionDto solutionAndStandardizitionDto)
        {


            await _service.UpdateAsync(_mapper.Map<SolutionAndStandardizition>(solutionAndStandardizitionDto));

            return RedirectToAction(nameof(Index));


        }

         public async Task<IActionResult> ShowSolutionAndStandardizition(Guid id)
        {
            var solutionList = await _service.GetByIdAsync(id);

            var errorClosingReasons = await _errorClosingReasonService.GetAllAsync();

            var errorClosingReasonDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReasons.Where(x => !x.IsDeleted));
            ViewBag.errorClosingReasons = new SelectList(errorClosingReasonDto, "Id", "Reason", solutionList.ErrorClosingReasonId);


            return View(_mapper.Map<SolutionAndStandardizitionDto>(solutionList));
        }

        [HttpPost]
        public async Task<IActionResult> ShowSolutionAndStandardizition(SolutionAndStandardizitionDto solutionAndStandardizitionDto)
        {
            await _service.UpdateAsync(_mapper.Map<SolutionAndStandardizition>(solutionAndStandardizitionDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteSolutionAndStandardizition(Guid id)
        {
            var solutionList = await _service.GetByIdAsync(id);

            var errorClosingReasons = await _errorClosingReasonService.GetAllAsync();

            var errorClosingReasonDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReasons.Where(x => !x.IsDeleted));
            ViewBag.errorClosingReasons = new SelectList(errorClosingReasonDto, "Id", "Reason", solutionList.ErrorClosingReasonId);


            return View(_mapper.Map<SolutionAndStandardizitionDto>(solutionList));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteSolutionAndStandardizition(SolutionAndStandardizitionDto solutionAndStandardizitionDto)
        {
            await _service.UpdateAsync(_mapper.Map<SolutionAndStandardizition>(solutionAndStandardizitionDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var solutionAndStandardizition = await _service.GetByIdAsync(id);
            solutionAndStandardizition.IsDeleted = true;
            await _service.UpdateAsync(solutionAndStandardizition);
            return RedirectToAction(nameof(Index));
        }

    }
}
