using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StartApi.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
namespace StartApi.Modules.Tools.Fields;
public class FieldsController : MyController
{
    private readonly IMapper _mapper;
    private readonly IFieldsRepository _repository;
    public FieldsController(
        IFieldsRepository repository, IMapper mapper
    )
    {
        _mapper = mapper;
        _repository = repository;
    }
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        var iQueryable = _repository.GetAll();
        var results = _mapper.ProjectTo<FieldsDetailResponse>(iQueryable).ToList();
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetId(Guid id)
    {
        var Fields = _repository.GetSingle(e => e.Id == id);
        if (Fields== null)
        {
            return BadRequest($"FieldsLine Not Found {id}");
        }
        var result = _mapper.Map<FieldsDetailResponse>(Fields);
        return Ok(result);

    }

    [HttpPost]
    public IActionResult Post([FromForm] FieldsUpdateRequest request)
    {
        var Fields = _mapper.Map<Fields>(request);
        Fields.CreatedAt = DateTime.UtcNow;
        _repository.Add(Fields);
        _repository.Commit();
        return NoContent();
        

    }

    [HttpPut("{id:guid}")]
    public IActionResult Update([FromForm] Guid id, FieldsUpdateRequest request)
    {
        var Fields = _repository.GetSingle(e => e.Id == id);
        if (Fields == null)
        {
            return BadRequest("Item Not Found {id}");
        }

        _mapper.Map(request, Fields);
        Fields.UpdatedAt = DateTime.UtcNow;
        _repository.Update(Fields);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public IActionResult Deleted(Guid id)
    {
        var Fields = _repository.GetSingle(e => e.Id == id);
        if ( Fields == null)
        {
            return BadRequest("Item Not Found {id}");
        }
        Fields.DeletedAt = DateTime.UtcNow;
        _repository.Remove(Fields);
        _repository.Commit();
        return NoContent();

    }
    
    // [HttpGet]
    // public IActionResult GetAll()
    //     {
    //      var FieldsLine = _repository.GetAll(); // Get FieldsLine from repository
    //         var itemDtos = _mapper.Map<IEnumerable<FieldsLineDetailResponse>>(FieldsLine); // Map to DTOs
    //         return Ok(itemDtos);
    //     }
//     [HttpGet("test")]
// public string Test() => "Works!";

}