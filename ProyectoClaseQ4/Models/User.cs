using Google.Cloud.Firestore;

namespace ProyectoClaseQ4.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string Id { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string Email { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string Fullname { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string Role { get; set; } = "user"; //"admin" o "user"
        
        [FirestoreProperty]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [FirestoreProperty]
        public bool IsActive { get; set; } = true;
    }
}