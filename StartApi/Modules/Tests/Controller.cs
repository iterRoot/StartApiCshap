// using AutoMapper;
// using Microsoft.AspNetCore.Mvc;
// using StartApi.Core;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.AspNetCore.Authorization;
// namespace StartApi.Modules.Company;
// public class CompanyController : MyController
// {
//     private readonly IMapper _mapper;
//     private readonly ICompanyRepository _repository;
//     public CompanyController(
//         ICompanyRepository repository, IMapper mapper
//     )
//     {
//         _mapper = mapper;
//         _repository = repository;
//     }
//     [AllowAnonymous]
//     [HttpGet]
//     public IActionResult Get()
//     {
//         var iQueryable = _repository.GetAll();
//         var results = _mapper.ProjectTo<CompanyDetailResponse>(iQueryable).ToList();
//         return Ok(results);
//     }

//     [HttpGet("{id:guid}")]
//     public IActionResult GetId(Guid id)
//     {
//         var Company = _repository.GetSingle(e => e.Id == id);
//         if (Company== null)
//         {
//             return BadRequest($"CompanyLine Not Found {id}");
//         }
//         var result = _mapper.Map<CompanyDetailResponse>(Company);
//         return Ok(result);

//     }

//     [HttpPost]
//     public IActionResult Post([FromForm] CompanyUpdateRequest request)
//     {
//         var Company = _mapper.Map<Company>(request);
//         Company.CreatedAt = DateTime.UtcNow;
//         _repository.Add(Company);
//         _repository.Commit();
//         return NoContent();
        

//     }

//     [HttpPut("{id:guid}")]
//     public IActionResult Update([FromForm] Guid id, CompanyUpdateRequest request)
//     {
//         var Company = _repository.GetSingle(e => e.Id == id);
//         if (Company == null)
//         {
//             return BadRequest("Item Not Found {id}");
//         }

//         _mapper.Map(request, Company);
//         Company.UpdatedAt = DateTime.UtcNow;
//         _repository.Update(Company);
//         _repository.Commit();
//         return NoContent();
//     }

//     [HttpDelete("id:guid")]
//     public IActionResult Deleted(Guid id)
//     {
//         var Company = _repository.GetSingle(e => e.Id == id);
//         if ( Company == null)
//         {
//             return BadRequest("Item Not Found {id}");
//         }
//         Company.DeletedAt = DateTime.UtcNow;
//         _repository.Remove(Company);
//         _repository.Commit();
//         return NoContent();

//     }
    
//     // [HttpGet]
//     // public IActionResult GetAll()
//     //     {
//     //      var CompanyLine = _repository.GetAll(); // Get CompanyLine from repository
//     //         var itemDtos = _mapper.Map<IEnumerable<CompanyLineDetailResponse>>(CompanyLine); // Map to DTOs
//     //         return Ok(itemDtos);
//     //     }
// //     [HttpGet("test")]
// // public string Test() => "Works!";

// }