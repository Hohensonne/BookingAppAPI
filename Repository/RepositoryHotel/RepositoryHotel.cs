using Data;
using DTO.HotelDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryHotel
{
   
        public class RepositoryHotel(ApplicationContext context) : IRepositoryHotel
        {
            private readonly ApplicationContext _context = context;
            private DbSet<Hotel> _hotels = context.Set<Hotel>();
            private DbSet<Rating> _ratings = context.Set<Rating>();


            public HotelDto Get(Guid id)
            {
                var hotel = _hotels.SingleOrDefault(x => x.Id == id);
                if (hotel == null) return null;
                HotelDto hotelDto = new HotelDto()
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Info = hotel.Info
                };
                return hotelDto;

            }

            public List<HotelDto> GetAll()
            {
                var hotels = _hotels.ToList();
                List<HotelDto> hotelsDto = new List<HotelDto>();

                foreach (var hotel in hotels)
                {
                    hotelsDto.Add(new HotelDto
                    {
                        Id = hotel.Id,
                        Name = hotel.Name,
                        Info = hotel.Info
                    });
                }
                return hotelsDto;
            }
            public void Insert(CreateHotelDto dto)
            {
                var hotel = new Hotel()
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Info = dto.Info
                };
                var rating = new Rating()
                {
                    Id = hotel.Id,
                    IdHotel = hotel.Id,
                    StarRating = dto.StarRating
                };
                _ratings.Add(rating);

                _hotels.Add(hotel);
                context.SaveChanges();
            }
            public void Update(UpdateHotelDto dto)
            {
                var hotel = _hotels.SingleOrDefault(x => x.Id == dto.Id);
                if (hotel == null) return;
                
                hotel.Name = dto.Name;
                hotel.Info = dto.Info;

                _hotels.Update(hotel);
                context.SaveChanges();

            }

            public void Delete(Guid id)
            {
                var hotel = _hotels.SingleOrDefault(x => x.Id == id);
                if (hotel == null) return;
                _hotels.Remove(hotel);
                context.SaveChanges();
            }

            public void SaveChanges()
            {
                context.SaveChanges();
            }
        }
    }

