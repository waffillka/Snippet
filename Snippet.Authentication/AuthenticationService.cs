using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;

namespace Snippet.Authentication
{
    public class AuthenticationService
    {
        private static readonly FirebaseAuth Auth = FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance); 
        
        public async Task Validate()
        {
            var idToken =
                "eyJhbGciOiJSUzI1NiIsImtpZCI6ImFlMDVlZmMyNTM2YjJjZTdjNTExZjRiMTcyN2I4NTkyYTc5ZWJiN2UiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vc25pcHBldHMtYXV0aGVudGljYXRpb24iLCJhdWQiOiJzbmlwcGV0cy1hdXRoZW50aWNhdGlvbiIsImF1dGhfdGltZSI6MTYyODQzMzg1MCwidXNlcl9pZCI6IkJtQ3pYemNQM1RSam9uR1ZwRWgwUWczQ2JZajEiLCJzdWIiOiJCbUN6WHpjUDNUUmpvbkdWcEVoMFFnM0NiWWoxIiwiaWF0IjoxNjI4NDMzODUwLCJleHAiOjE2Mjg0Mzc0NTAsImVtYWlsIjoiemhhdm9yb25rb3YuMDJAbWFpbC5ydSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJlbWFpbCI6WyJ6aGF2b3Jvbmtvdi4wMkBtYWlsLnJ1Il19LCJzaWduX2luX3Byb3ZpZGVyIjoicGFzc3dvcmQifX0.jl1pE-HKkEKb2JiMgQU1a7o51lDlZ0Aio_wLyW1nsAk3AUlvUYK1L09wY19FY7RY5TQ4URtJww7yHqKYq8hpqLUWWq3r7sQK_nFEOqmedobOmQCblX5GW2S1w769xdo_8aMGlXokBeZwxAyeGgidgSO_o4E1Va6cQLft0WPIC6clVbS84mWCAaTGWLdVv0Z2oHLX6RwLh22zflf7R-Kvm0CJysJyqmbjYgRjD2uVJaM8MGVRA-VwEbSmnR-1rePRNesAdPp1BY45bbLMREGDALWl7RROvObjj_OyEYAWLFzBukXdhS1SKBZFhSYmA1YesXYTPfLpJwLhvEbSdvAnpg";
            FirebaseToken decodedToken = await Auth.VerifyIdTokenAsync(idToken);
            
        }
    }
}