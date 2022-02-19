using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

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
            string path = @"C:\Windows\Temp\user" + id + ".json";

            if (System.IO.File.Exists(path))
            {
                StreamReader r = new StreamReader(path);
                string jsonString = r.ReadToEnd();
                r.Close();
                return jsonString;
            } else {
                return "No existe informacion del usuario";
            }

        }


        [HttpPost]
        [Route("InsertUsuario")]
        public string Post(UsuariosDto usuario)
        {
            int id = 1;
            string path = @"C:\Windows\Temp\user" + id + ".json";

            while (System.IO.File.Exists(path))
            {
                id = id + 1;
                path = @"C:\Windows\Temp\user" + id + ".json";
            }
            string jsonS = System.Text.Json.JsonSerializer.Serialize(usuario);
            System.IO.File.WriteAllText(path, jsonS);
            return usuario.Nombre+" Ingresado exitosamente";
        }


        [HttpPut]
        [Route("AddDate/{id}/{tipe}/{info}")]
        public string Put(int id, string tipe, string info)
        {
            string path = @"C:\Windows\Temp\user"+id+".json";
            if (System.IO.File.Exists(path))
            {
                StreamReader r = new StreamReader(path);
                string jsonString = r.ReadToEnd();
                r.Close();
                UsuariosDto m = JsonConvert.DeserializeObject<UsuariosDto>(jsonString);
                switch (tipe)
                {
                    case "Nombre" :
                        m.Nombre = info;
                        string jsonS = System.Text.Json.JsonSerializer.Serialize(m);
                        System.IO.File.WriteAllText(path, jsonS);
                        return "Nombre cambiado";
                    case "Apellido":
                        m.Apellido = info;
                        string jsonS1 = System.Text.Json.JsonSerializer.Serialize(m);
                        System.IO.File.WriteAllText(path, jsonS1);
                        return "Apellido cambiado";
                    case "Sexo":
                        m.Sexo = info;
                        string jsonS2 = System.Text.Json.JsonSerializer.Serialize(m);
                        System.IO.File.WriteAllText(path, jsonS2);
                        return "Sexo cambiado";
                    case "Correo":
                        m.Correo = info;
                        string jsonS3 = System.Text.Json.JsonSerializer.Serialize(m);
                        System.IO.File.WriteAllText(path, jsonS3);
                        return "Correo cambiado";
                    case "Telefono":
                        m.Telefono = info;
                        string jsonS4 = System.Text.Json.JsonSerializer.Serialize(m);
                        System.IO.File.WriteAllText(path, jsonS4);
                        return "Telefono cambiado";
                    case "Edad":
                        m.Edad = info;
                        string jsonS5 = System.Text.Json.JsonSerializer.Serialize(m);
                        System.IO.File.WriteAllText(path, jsonS5);
                        return "Edad cambiado";
                    default:
                        return "Informacion de entrada incorrecta";
                }
            }else
            {
                return "Informacion de usuario no existente";
            }
        }


        [HttpDelete]
        [Route("EliminarPerfil/{id}")]
        public string Delete(int id)
        {
            string usser = "user" + id + ".json";
            string path = @"C:\Windows\Temp\"+usser;

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return "Usuario eliminado";
            } else
            {
                return "No existe";
            }
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
