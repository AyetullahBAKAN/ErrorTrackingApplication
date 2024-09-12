using AutoMapper;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Service;

namespace WEB.Controllers
{
    [Authorize]
    public class ErrorCardController : Controller
    {
        private readonly ErrorCardService _service;
        private readonly UserService _userService; // ++
        private readonly ProjectService _projectService;
        private readonly PatternService _patternService;
        private readonly CustomerService _customerService;
        private readonly PartService _partService;
        private readonly MontageLetterService _montageLetterService;
        private readonly OperationService _operationService;
        private readonly ErrorDefineService _errorDefineService; // ++
        private readonly ErrorClassService _errorClassService;
        private readonly RootAnalysisService _rootAnalysisService;
        private readonly SolutionAndStandardizitonService _solutionServices;
        private readonly CostService _costService;
        private readonly ErrorDetectionLocationService _errorDetectionLocationService; // ++
        private readonly UnitService _unitService; // ++
        private readonly StateService _stateService; // ++
        private readonly IMapper _mapper;
        public ErrorCardController(ErrorCardService service, UserService userService, PatternService patternService,
            ErrorDefineService errorDefineService, ErrorClassService errorClassService, RootAnalysisService rootAnalysisService,
            SolutionAndStandardizitonService solutionServices, CostService costService, 
            ErrorDetectionLocationService errorDetectionLocationService,UnitService unitService, 
            StateService stateService, ProjectService projectService,
            CustomerService customerService, PartService partService, MontageLetterService montageLetterService, 
            OperationService operationService,  IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _patternService = patternService;
            _errorDefineService = errorDefineService;
            _errorClassService = errorClassService;
            _rootAnalysisService = rootAnalysisService;
            _solutionServices = solutionServices;
            _costService = costService;
            _errorDetectionLocationService = errorDetectionLocationService;
            _unitService = unitService;
            _stateService = stateService;
            _mapper = mapper;
            _projectService = projectService;
            _customerService = customerService;
            _partService = partService;
            _montageLetterService = montageLetterService;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorCardAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorCards = await _service.GetAllAsync();
            var errorCardsDto = _mapper.Map<List<ErrorCardDto>>(errorCards.ToList());

            return View(CustomResponseDto<List<ErrorCardDto>>.Success(200, errorCardsDto));
        }

        

        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var errorCards = await _service.GetAsync(x => x.Id == id, "Pattern.Customer,Pattern.Project," +
                "Pattern.Part,Pattern.MontageLetter,Pattern.Operation,User,Cost,ErrorClass," +
                "ErrorDefine,ErrorDetectionLocation,RootAnalysis,SolutionAndStandardizition,Unit,States");

            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(usersDto, "Id", "UserName", errorCards.UserId);

            var projects = await _projectService.GetAllAsync();
            var projectsDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.projects = new SelectList(projectsDto, "Id", "ProjectName", errorCards.Pattern.ProjectId);

            var customers = await _customerService.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.customers = new SelectList(customersDto, "Id", "CustomerName", errorCards.Pattern.CustomerId);

            var montageLetter = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetter.Where(x => !x.IsDeleted));
            ViewBag.montageLetter = new SelectList(montageLetterDto, "Id", "MontageNumber", errorCards.Pattern.MontageLetterId);

            var partList = await _partService.GetAllAsync();
            var partListDto = _mapper.Map<List<PartDto>>(partList.Where(x => !x.IsDeleted));
            ViewBag.partList = new SelectList(partListDto, "Id", "PartNo", errorCards.Pattern.PartId);

            var operationList = await _operationService.GetAllAsync();
            var operationListDto = _mapper.Map<List<OperationDto>>(operationList.Where(x => !x.IsDeleted));
            ViewBag.operationList = new SelectList(operationListDto, "Id", "OperationNo", errorCards.Pattern.OperationId);

            var costList = await _costService.GetAllAsync();
            var costListDto = _mapper.Map<List<CostDto>>(costList.Where(x => !x.IsDeleted));
            ViewBag.costList = new SelectList(costListDto, "Id", "Description", errorCards.CostId);


            var errorClassList = await _errorClassService.GetAllAsync();
            var errorClassListDto = _mapper.Map<List<ErrorClassDto>>(errorClassList.Where(x => !x.IsDeleted));
            ViewBag.errorClassList = new SelectList(errorClassListDto, "Id", "ShortDetail", errorCards.ErrorClassId);

            var errorDefineList = await _errorDefineService.GetAllAsync();
            var errorDefineListDto = _mapper.Map<List<ErrorDefineDto>>(errorDefineList.Where(x => !x.IsDeleted));
            ViewBag.errorDefineList = new SelectList(errorDefineListDto, "Id", "ErrorExplain", errorCards.ErrorDefineId);


            var errorDetectionList = await _errorDetectionLocationService.GetAllAsync();
            var errorDetectionListDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorDetectionList.Where(x => !x.IsDeleted));
            ViewBag.errorDetectionList = new SelectList(errorDetectionListDto, "Id", "ErrorLocation", errorCards.ErrorDetectionLocationId);


            var unitList = await _unitService.GetAllAsync();
            var unitListDto = _mapper.Map<List<UnitDto>>(unitList.Where(x => !x.IsDeleted));
            ViewBag.unitList = new SelectList(unitListDto, "Id", "UnitName", errorCards.UnitId);


            var solutionList = await _solutionServices.GetAllAsync();
            var solutionListDto = _mapper.Map<List<SolutionAndStandardizitionDto>>(solutionList.Where(x => !x.IsDeleted));
            ViewBag.solutionList = new SelectList(solutionListDto, "Id", "HowErrorClose", errorCards.ErrorDetectionLocationId);


            var stateList = await _stateService.GetAllAsync();
            var stateListDto = _mapper.Map<List<StateDto>>(stateList.Where(x => !x.IsDeleted));
            ViewBag.stateList = new SelectList(stateListDto, "Id", "StateName", errorCards.StateId);

            var rootAnalysisList = await _rootAnalysisService.GetAllAsync();
            var rootAnalysisDto = _mapper.Map<List<RootAnalysisDto>>(rootAnalysisList.Where(x => !x.IsDeleted));
            ViewBag.rootAnalysisList = new SelectList(rootAnalysisDto, "Id", "Result", errorCards.RootAnalysisId);

            return View(_mapper.Map<ErrorCardDto>(errorCards));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorCardDto errorCardDto)
        {
            var gg = await _service.GetAsync(x => x.Id == errorCardDto.Id, "Pattern.Customer,Pattern.Project," +
                "Pattern.Part,Pattern.MontageLetter,Pattern.Operation,User,Cost,ErrorClass," +
                "ErrorDefine,ErrorDetectionLocation,RootAnalysis,SolutionAndStandardizition,Unit,States");
            if (gg != null) 
            {
                
                _mapper.Map(errorCardDto, gg);
                await _service.UpdateAsync(gg);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ShowCard(Guid id)
        {
            var errorCards = await _service.GetAsync(x => x.Id == id, "Pattern.Customer,Pattern.Project," +
                "Pattern.Part,Pattern.MontageLetter,Pattern.Operation,User,Cost,ErrorClass," +
                "ErrorDefine,ErrorDetectionLocation,RootAnalysis,SolutionAndStandardizition,Unit,States");

            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(usersDto, "Id", "UserName", errorCards.UserId);

            var projects = await _projectService.GetAllAsync();
            var projectsDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.projects = new SelectList(projectsDto, "Id", "ProjectName", errorCards.Pattern.ProjectId);

            var customers = await _customerService.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.customers = new SelectList(customersDto, "Id", "CustomerName", errorCards.Pattern.CustomerId);

            var montageLetter = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetter.Where(x => !x.IsDeleted));
            ViewBag.montageLetter = new SelectList(montageLetterDto, "Id", "MontageNumber", errorCards.Pattern.MontageLetterId);

            var partList = await _partService.GetAllAsync();
            var partListDto = _mapper.Map<List<PartDto>>(partList.Where(x => !x.IsDeleted));
            ViewBag.partList = new SelectList(partListDto, "Id", "PartNo", errorCards.Pattern.PartId);

            var operationList = await _operationService.GetAllAsync();
            var operationListDto = _mapper.Map<List<OperationDto>>(operationList.Where(x => !x.IsDeleted));
            ViewBag.operationList = new SelectList(operationListDto, "Id", "OperationNo", errorCards.Pattern.OperationId);

            var costList = await _costService.GetAllAsync();
            var costListDto = _mapper.Map<List<CostDto>>(costList.Where(x => !x.IsDeleted));
            ViewBag.costList = new SelectList(costListDto, "Id", "Description", errorCards.CostId);


            var errorClassList = await _errorClassService.GetAllAsync();
            var errorClassListDto = _mapper.Map<List<ErrorClassDto>>(errorClassList.Where(x => !x.IsDeleted));
            ViewBag.errorClassList = new SelectList(errorClassListDto, "Id", "ShortDetail", errorCards.ErrorClassId);

            var errorDefineList = await _errorDefineService.GetAllAsync();
            var errorDefineListDto = _mapper.Map<List<ErrorDefineDto>>(errorDefineList.Where(x => !x.IsDeleted));
            ViewBag.errorDefineList = new SelectList(errorDefineListDto, "Id", "ErrorExplain", errorCards.ErrorDefineId);


            var errorDetectionList = await _errorDetectionLocationService.GetAllAsync();
            var errorDetectionListDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorDetectionList.Where(x => !x.IsDeleted));
            ViewBag.errorDetectionList = new SelectList(errorDetectionListDto, "Id", "ErrorLocation", errorCards.ErrorDetectionLocationId);


            var unitList = await _unitService.GetAllAsync();
            var unitListDto = _mapper.Map<List<UnitDto>>(unitList.Where(x => !x.IsDeleted));
            ViewBag.unitList = new SelectList(unitListDto, "Id", "UnitName", errorCards.UnitId);


            var solutionList = await _solutionServices.GetAllAsync();
            var solutionListDto = _mapper.Map<List<SolutionAndStandardizitionDto>>(solutionList.Where(x => !x.IsDeleted));
            ViewBag.solutionList = new SelectList(solutionListDto, "Id", "HowErrorClose", errorCards.ErrorDetectionLocationId);


            var stateList = await _stateService.GetAllAsync();
            var stateListDto = _mapper.Map<List<StateDto>>(stateList.Where(x => !x.IsDeleted));
            ViewBag.stateList = new SelectList(stateListDto, "Id", "StateName", errorCards.StateId);

            var rootAnalysisList = await _rootAnalysisService.GetAllAsync();
            var rootAnalysisDto = _mapper.Map<List<RootAnalysisDto>>(rootAnalysisList.Where(x => !x.IsDeleted));
            ViewBag.rootAnalysisList = new SelectList(rootAnalysisDto, "Id", "Result", errorCards.RootAnalysisId);

            return View(_mapper.Map<ErrorCardDto>(errorCards));
        }

        [HttpPost]
        public async Task<IActionResult> ShowCard(ErrorCardDto errorCardDto)
        {
            var gg = await _service.GetAsync(x => x.Id == errorCardDto.Id, "Pattern.Customer,Pattern.Project," +
                "Pattern.Part,Pattern.MontageLetter,Pattern.Operation,User,Cost,ErrorClass," +
                "ErrorDefine,ErrorDetectionLocation,RootAnalysis,SolutionAndStandardizition,Unit,States");
            if (gg != null)
            {

                _mapper.Map(errorCardDto, gg);
                await _service.UpdateAsync(gg);
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var errorCards = await _service.GetAsync(x => x.Id == id, "Pattern.Customer,Pattern.Project," +
                "Pattern.Part,Pattern.MontageLetter,Pattern.Operation,User,Cost,ErrorClass," +
                "ErrorDefine,ErrorDetectionLocation,RootAnalysis,SolutionAndStandardizition,Unit,States");

            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(usersDto, "Id", "UserName", errorCards.UserId);

            var projects = await _projectService.GetAllAsync();
            var projectsDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.projects = new SelectList(projectsDto, "Id", "ProjectName", errorCards.Pattern.ProjectId);

            var customers = await _customerService.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.customers = new SelectList(customersDto, "Id", "CustomerName", errorCards.Pattern.CustomerId);

            var montageLetter = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetter.Where(x => !x.IsDeleted));
            ViewBag.montageLetter = new SelectList(montageLetterDto, "Id", "MontageNumber", errorCards.Pattern.MontageLetterId);

            var partList = await _partService.GetAllAsync();
            var partListDto = _mapper.Map<List<PartDto>>(partList.Where(x => !x.IsDeleted));
            ViewBag.partList = new SelectList(partListDto, "Id", "PartNo", errorCards.Pattern.PartId);

            var operationList = await _operationService.GetAllAsync();
            var operationListDto = _mapper.Map<List<OperationDto>>(operationList.Where(x => !x.IsDeleted));
            ViewBag.operationList = new SelectList(operationListDto, "Id", "OperationNo", errorCards.Pattern.OperationId);

            var costList = await _costService.GetAllAsync();
            var costListDto = _mapper.Map<List<CostDto>>(costList.Where(x => !x.IsDeleted));
            ViewBag.costList = new SelectList(costListDto, "Id", "Description", errorCards.CostId);


            var errorClassList = await _errorClassService.GetAllAsync();
            var errorClassListDto = _mapper.Map<List<ErrorClassDto>>(errorClassList.Where(x => !x.IsDeleted));
            ViewBag.errorClassList = new SelectList(errorClassListDto, "Id", "ShortDetail", errorCards.ErrorClassId);

            var errorDefineList = await _errorDefineService.GetAllAsync();
            var errorDefineListDto = _mapper.Map<List<ErrorDefineDto>>(errorDefineList.Where(x => !x.IsDeleted));
            ViewBag.errorDefineList = new SelectList(errorDefineListDto, "Id", "ErrorExplain", errorCards.ErrorDefineId);


            var errorDetectionList = await _errorDetectionLocationService.GetAllAsync();
            var errorDetectionListDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorDetectionList.Where(x => !x.IsDeleted));
            ViewBag.errorDetectionList = new SelectList(errorDetectionListDto, "Id", "ErrorLocation", errorCards.ErrorDetectionLocationId);


            var unitList = await _unitService.GetAllAsync();
            var unitListDto = _mapper.Map<List<UnitDto>>(unitList.Where(x => !x.IsDeleted));
            ViewBag.unitList = new SelectList(unitListDto, "Id", "UnitName", errorCards.UnitId);


            var solutionList = await _solutionServices.GetAllAsync();
            var solutionListDto = _mapper.Map<List<SolutionAndStandardizitionDto>>(solutionList.Where(x => !x.IsDeleted));
            ViewBag.solutionList = new SelectList(solutionListDto, "Id", "HowErrorClose", errorCards.ErrorDetectionLocationId);


            var stateList = await _stateService.GetAllAsync();
            var stateListDto = _mapper.Map<List<StateDto>>(stateList.Where(x => !x.IsDeleted));
            ViewBag.stateList = new SelectList(stateListDto, "Id", "StateName", errorCards.StateId);

            var rootAnalysisList = await _rootAnalysisService.GetAllAsync();
            var rootAnalysisDto = _mapper.Map<List<RootAnalysisDto>>(rootAnalysisList.Where(x => !x.IsDeleted));
            ViewBag.rootAnalysisList = new SelectList(rootAnalysisDto, "Id", "Result", errorCards.RootAnalysisId);

            return View(_mapper.Map<ErrorCardDto>(errorCards));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteCard(ErrorCardDto errorCardDto)
        {
            var gg = await _service.GetAsync(x => x.Id == errorCardDto.Id, "Pattern.Customer,Pattern.Project," +
                "Pattern.Part,Pattern.MontageLetter,Pattern.Operation,User,Cost,ErrorClass," +
                "ErrorDefine,ErrorDetectionLocation,RootAnalysis,SolutionAndStandardizition,Unit,States");
            if (gg != null)
            {

                _mapper.Map(errorCardDto, gg);
                await _service.UpdateAsync(gg);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var errorCards = await _service.GetByIdAsync(id);
            errorCards.IsDeleted = true;
            await _service.UpdateAsync(errorCards);
            return RedirectToAction(nameof(Index));
        }
    }
}
