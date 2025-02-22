using Polotno.API.Models;

namespace Polotno.API.Services
{
    public class PictureService
    {
        private readonly PolotnoContext dbcontext;

        public PictureService(PolotnoContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public int getPictureId()
        {
            var today = DateTime.Today;
            int artistId;

            var birthdayArtistIds = dbcontext.Artists
                                                .Where(a => a.DateOfBirth.HasValue &&
                                                            a.DateOfBirth.Value.Day == today.Day &&
                                                            a.DateOfBirth.Value.Month == today.Month)
                                                .Select(a => a.ArtistId)
                                                .ToList();

            if (birthdayArtistIds.Any())
            {
                artistId = birthdayArtistIds[0];
            }else{
                var artistIds = dbcontext.Artists.Select(a => a.ArtistId).ToList();
                Random random = new Random();
                artistId = artistIds[random.Next(artistIds.Count)]; 
            }

            var firstPaintingId = dbcontext.Paintings
                                            .Where(p => p.ArtistId == artistId)  
                                            .Select(p => p.PaintingId)            
                                            .FirstOrDefault();  
            //можливо варто додати перевірку на випадок коли у artist не буде картин і firstPaintingId=0
            return firstPaintingId;
        }
    }
}