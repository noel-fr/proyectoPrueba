using Microsoft.AspNetCore.Mvc;
using ProyectoClaseQ4.Services;

namespace ProyectoClaseQ4.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly FirebaseServices _firebaseServices;

        public TestController(FirebaseServices firebaseServices)
        {
            _firebaseServices = firebaseServices;
        }

        [HttpGet("firebase")]
        public async Task<IActionResult> TestFirebase()
        {
            try
            {
                var db = _firebaseServices.GetFirestoreDb();

                //Intentar leer la coleccion de users
                var usersCollection = _firebaseServices.GetCollection("users");
                var snapshot = await usersCollection.Limit(1).GetSnapshotAsync();

                return Ok(new
                {
                    success = true,
                    message = "Conexion exitosa",
                    projectId = db.ProjectId,
                    documentsFounds = snapshot.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error al conectar con Firebase",
                    error = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new
            {
                status = "API funcionando correctamente",
                timestamp = DateTime.UtcNow
            });
        }
    }
}