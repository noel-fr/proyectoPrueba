using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace ProyectoClaseQ4.Services;

public class FirebaseServices
{
    private readonly FirestoreDb _firestoreDb;
    private readonly string _projectId;

    public FirebaseServices(IConfiguration configuration)
    {
        _projectId = configuration["Firebase:ProjectId"]
            ?? throw new InvalidOperationException("Firebase ProjectID no configurado");
        
        //Inicializar Firebase App si no esta inicializado
        if (FirebaseApp.DefaultInstance == null)
        {
            var credential = GoogleCredential.GetApplicationDefault();
            FirebaseApp.Create(new AppOptions
            {
                Credential = credential,
                ProjectId = _projectId
            });
            
        }
        
        //Crear instancia de Firebase
        _firestoreDb = FirestoreDb.Create(_projectId);    
    }
        
    public FirestoreDb GetFirestoreDb()
    {
        return _firestoreDb;
    }

    public CollectionReference GetCollection(string collectionName)
    {
        return _firestoreDb.Collection(collectionName);   
    }
}