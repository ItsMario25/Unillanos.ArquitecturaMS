using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using System.IO;
using System.Text;

namespace Unillanos.ArquitecturaMS.Usuarios.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        [Route("LeerPerfil/{id}")]

        public string Get(int id)
        {
            return id switch
            {
                1 => "Mario",
                2 => "Curso",
                _ => throw new System.NotSupportedException("El id no es valido")
            };
        }

        [HttpPost]
        [Route("InsertUsuario")]
        public string Post(UsuariosDto usuario)
        {
            string path = @"C:\Windows\Temp\user1.json";

            // Delete the file if it exists.
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            string jsonString = JsonSerializer.Serialize(usuario);
            System.IO.File.WriteAllText(path, jsonString);


            return usuario.Nombre;
        }

        [HttpPut]
        [Route("AddUsuario")]
        public string Put(UsuariosDto user)
        {
            string path = @"C:\Windows\Temp\user1.json";
            return user.Nombre;
        }


        [HttpDelete]
        [Route("AddUsuario")]
        public string Delete(UsuariosDto user)
        {
            return "gelo";
        }

        public class UsuariosDto
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Sexo { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public string Edad { get; set; }
        }

    }
}
