using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StartApi.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
namespace StartApi.Modules.Inventory.ItemMaster;
public class ItemMasterController : MyController
{
    private readonly IMapper _mapper;
    private readonly IItemMasterRepository _repository;
    public ItemMasterController(
        IItemMasterRepository repository, IMapper mapper
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
        var results = _mapper.ProjectTo<ItemMasterDetailResponse>(iQueryable).ToList();
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetId(Guid id)
    {
        var ItemMaster = _repository.GetSingle(e => e.Id == id);
        if (ItemMaster== null)
        {
            return BadRequest($"ItemMasterLine Not Found {id}");
        }
        var result = _mapper.Map<ItemMasterDetailResponse>(ItemMaster);
        return Ok(result);

    }

    [HttpPost]
    public IActionResult Post([FromForm] ItemMasterUpdateRequest request)
    {
        var ItemMaster = _mapper.Map<ItemMaster>(request);
        ItemMaster.CreatedAt = DateTime.UtcNow;
        _repository.Add(ItemMaster);
        _repository.Commit();
        return NoContent();
        

    }

    [HttpPut("{id:guid}")]
    public IActionResult Update([FromForm] Guid id, ItemMasterUpdateRequest request)
    {
        var ItemMaster = _repository.GetSingle(e => e.Id == id);
        if (ItemMaster == null)
        {
            return BadRequest("Item Not Found {id}");
        }

        _mapper.Map(request, ItemMaster);
        ItemMaster.UpdatedAt = DateTime.UtcNow;
        _repository.Update(ItemMaster);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public IActionResult Deleted(Guid id)
    {
        var ItemMaster = _repository.GetSingle(e => e.Id == id);
        if ( ItemMaster == null)
        {
            return BadRequest("Item Not Found {id}");
        }
        ItemMaster.DeletedAt = DateTime.UtcNow;
        _repository.Remove(ItemMaster);
        _repository.Commit();
        return NoContent();

    }
    
    // [HttpGet]
    // public IActionResult GetAll()
    //     {
    //      var ItemMasterLine = _repository.GetAll(); // Get ItemMasterLine from repository
    //         var itemDtos = _mapper.Map<IEnumerable<ItemMasterLineDetailResponse>>(ItemMasterLine); // Map to DTOs
    //         return Ok(itemDtos);
    //     }
//     [HttpGet("test")]
// public string Test() => "Works!";

}