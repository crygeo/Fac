using InventaSINC.Objs.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InventaSINC.Objs
{
    public class Usuario : IIdentifiable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // ID del usuario
        public string PrimerNombre { get; set; } // Primer nombre del usuario
        public string SegundoNombre { get; set; } // Segundo nombre del usuario
        public string PrimerApellido { get; set; } // Primer apellido del usuario
        public string SegundoApellido { get; set; } // Segundo apellido del usuario
        public string Cedula { get; set; } // Cedula de identidad
        public string Celular { get; set; } // Numero de telefono
        public DateTime FechaNacimiento { get; set; } // Fecha de nacimiento del usuario

        public string User { get; set; } // Nombre de usuario
        public string Password { get; set; } // Contraseña
    }

}
