using Google.Cloud.Firestore;
namespace ProyectoClaseQ4.Models
{
    [FirestoreData]
    public class TaskItem
    {
        [FirestoreProperty]
        public string Id { get; set; } =  string.Empty;
        
        [FirestoreProperty]
        public string Title { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string Description { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string AssignedToUserId { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string CreatedByUserId { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public string CreatedByUserName { get; set; } = string.Empty;
        
        [FirestoreProperty]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [FirestoreProperty]
        public DateTime? DueDate { get; set; }
        
        [FirestoreProperty]
        public DateTime? CompletedAt { get; set; }

        [FirestoreProperty] 
        public bool IsCompleted { get; set; } = false;

        [FirestoreProperty]
        public string Priority { get; set; } = "medium";
        
        [FirestoreProperty]
        public string Status { get; set; } = "pending";
    }
}