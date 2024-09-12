using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class RootAnalysisController : Controller
    {
        private readonly RootAnalysisService _service;
        private readonly IMapper _mapper;
        public RootAnalysisController(RootAnalysisService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetRootAnalysisListAsync();
            if (result == null || !result.Any())
                return BadRequest();

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var root = await _service.GetAllAsync();
            var rootDto = _mapper.Map<List<RootAnalysisDto>>(root.ToList());

            return View(CustomResponseDto<List<RootAnalysisDto>>.Success(200, rootDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var root = await _service.GetAllAsync();
            var rootDto = _mapper.Map<List<RootAnalysisDto>>(root.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(RootAnalysisDto rootAnalysisDto)
        {

            var root = await _service.AddAsync(_mapper.Map<RootAnalysis>(rootAnalysisDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var root = await _service.GetByIdAsync(id);

            return View(_mapper.Map<RootAnalysisDto>(root));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(RootAnalysisDto rootAnalysisDto)
        {


            await _service.UpdateAsync(_mapper.Map<RootAnalysis>(rootAnalysisDto));

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> ShowRootAnalysis(Guid id)
        {
            var root = await _service.GetByIdAsync(id);

            return View(_mapper.Map<RootAnalysisDto>(root));
        }


        [HttpPost]
        public async Task<IActionResult> ShowRootAnalysis(RootAnalysisDto rootAnalysisDto)
        {

            await _service.UpdateAsync(_mapper.Map<RootAnalysis>(rootAnalysisDto));

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteRootAnalysis(Guid id)
        {
            var root = await _service.GetByIdAsync(id);

            return View(_mapper.Map<RootAnalysisDto>(root));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteRootAnalysis(RootAnalysisDto rootAnalysisDto)
        {

            await _service.UpdateAsync(_mapper.Map<RootAnalysis>(rootAnalysisDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var root = await _service.GetByIdAsync(id);
            root.IsDeleted = true;
            await _service.UpdateAsync(root);
            return RedirectToAction(nameof(Index));
        }
    }
}
