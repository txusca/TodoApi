using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using TodoApi.Domain.Entity;
using TodoApi.Dtos;
using TodoApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly IRepository<Todo> _repository;
    private readonly IMapper _mapper;
    public TodosController(IRepository<Todo> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // GET: api/<TodosController>
    [EnableCors("AllowAnyOrigin")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var todos = await _repository.GetAll();
        return Ok(todos);
    }

    // GET api/<TodosController>/5
    [EnableCors("AllowAnyOrigin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var todo = await _repository.Get(id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    // POST api/<TodosController>
    [EnableCors("AllowAnyOrigin")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTodoDto todoDto)
    {
        var todo = _mapper.Map<Todo>(todoDto);
        todo.Id = Guid.NewGuid();
        todo.Completed = false;
        await _repository.Create(todo);
        return Ok(todo);

    }

    // PUT api/<TodosController>/5
    [EnableCors("AllowAnyOrigin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTodoDto todoDto)
    {
        var todo = _mapper.Map<Todo>(todoDto);
        await _repository.Update(id, todo);
        return Ok(todo);
    }

    // DELETE api/<TodosController>/5
    [EnableCors("AllowAnyOrigin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repository.Delete(id);
        return NoContent();
    }
}
