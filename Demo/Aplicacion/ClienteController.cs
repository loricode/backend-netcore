using Microsoft.AspNetCore.Mvc;
using Backend.Demo.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Backend.Demo.Persistencia;
using System.Collections.Generic;


namespace Backend.Demo.Aplicacion
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteContext _db;
        public ClienteController(ClienteContext db) {
          _db = db;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> stp_Listado_Clientes()
        {
            return await _db.Clientes.ToListAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> stp_Obtener_Cliente(int id)
        {
            
            var cliente = await _db.Clientes.FirstOrDefaultAsync(c => c.Identificacion.Equals(id.ToString()));

            if(cliente == null) {
                return NotFound();
            }

            return cliente;
        }


        [HttpGet("{id:int}/id")]
        public async Task<ActionResult<Cliente>> stp_Obtener_Cliente_Id(int id)
        {

            var cliente = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) {
                return NotFound();
            }

            return cliente;
        }


        [HttpPost("add")]
        public async Task<ActionResult> stp_Crear_Cliente([FromBody] Cliente cliente)
        {
           
            if (cliente == null) {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(cliente);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}/delete")]
        public async Task<ActionResult<Cliente>> stp_Eliminar_Cliente(int id)
        {

            var cliente = await _db.Clientes.FindAsync(id);

            if (cliente == null) {
                return NotFound();
            }

            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> stp_Editar_Cliente(int id, [FromBody] Cliente t)
        {
            var cliente = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            cliente.Nombre = t.Nombre;
            cliente.Apellido = t.Apellido;
            cliente.Identificacion = t.Identificacion;
            cliente.Telefono = t.Telefono;
            cliente.TelefonoOtros = t.TelefonoOtros;
            cliente.Direccion = t.Direccion;
            cliente.ResenaPersonal = t.ResenaPersonal;
            cliente.Sexo = t.Sexo;
            cliente.Imagen = t.Imagen;

             if (cliente == null) {
                return NotFound();
             }

           // _db.Entry(t).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("interes")]
        public async Task<ActionResult<List<Configuracion>>> getConfig()
        {
            var configuracions = await _db.Configuraciones.ToListAsync();
            return configuracions;
        }

    }
}