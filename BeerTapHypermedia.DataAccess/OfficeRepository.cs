using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using BeerTapHypermedia.DataAccess.Dtos;
using Castle.Core;
using IQ.Framework.Patterns.Mapping;

namespace BeerTapHypermedia.DataAccess
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IDatabaseContextFactory<BeerTapContext> _contextFactory;

        public OfficeRepository(IDatabaseContextFactory<BeerTapContext> contextFactory)
        {
            if (contextFactory == null) throw new ArgumentNullException(nameof(contextFactory));
            _contextFactory = contextFactory;
        }

        public OfficeKegDto Get(int officeId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var officeKeg = new OfficeKegDto() {Kegs = new List<KegDto>()};
                var officeIdParam = new SqlParameter { ParameterName = "@OfficeId", SqlDbType = SqlDbType.Int, Value = officeId};
                var results =
                    context.Database.SqlQuery<OfficeKegDto>("[dbo].[Office_Select] @OfficeId", officeIdParam).ToList();
                foreach (var officeKegDto in results)
                {
                    officeKeg.Id = officeKegDto.Id;
                    officeKeg.Name = officeKegDto.Name;
                    officeKeg.Description = officeKegDto.Description;
                    officeKeg.LocationId = officeKegDto.LocationId;
                    if(officeKegDto.KegId != null)
                        officeKeg.Kegs.Add(new KegDto() {KegId = officeKegDto.KegId, Quantity = officeKegDto.Quantity, BrandId = officeKegDto.BrandId });
                }
                return officeKeg;
            }
        }

        public IEnumerable<OfficeKegDto> GetAll()
        {
            var offices = new List<OfficeDto>();
            using (var context = _contextFactory.CreateContext())
            {
                var officeIdParam = new SqlParameter {ParameterName = "@OfficeId", SqlDbType = SqlDbType.Int, Value = 0};
                var results = context.Database.SqlQuery<OfficeKegDto>("[dbo].[Office_Select] @OfficeId", officeIdParam).ToList();
                foreach (var officeKegDto in results)
                {
                    if(!offices.Exists(o => o.Id == officeKegDto.Id))
                    offices.Add(new OfficeDto() {Id = officeKegDto.Id, Name = officeKegDto.Name, Description = officeKegDto.Description, LocationId = officeKegDto.LocationId });
                }
                var officeKegs = new List<OfficeKegDto>();
                foreach (var office in offices)
                {
                    var officeKeg = new OfficeKegDto()
                    {
                        Id = office.Id,
                        Name = office.Name,
                        Description = office.Description,
                        Kegs = new List<KegDto>()
                    };

                    foreach (var officeKegDto in results)
                    {
                        if (officeKegDto.KegId == null || office.Id != officeKegDto.Id) continue;
                        officeKeg.Kegs.Add(
                            new KegDto
                            {
                                KegId = officeKegDto.KegId,
                                BrandId = officeKegDto.BrandId,
                                Quantity = officeKegDto.Quantity
                            });
                    }
                    officeKegs.Add(officeKeg);
                }
                return officeKegs;
            }
        }

        public int Save(OfficeDto office)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var officeName = new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar,  Value = office.Name };
                var officeDescription = new SqlParameter { ParameterName = "@Description", SqlDbType = SqlDbType.VarChar, Value = office.Description };
                var officeLocationId = new SqlParameter { ParameterName = "@LocationId", SqlDbType = SqlDbType.Int, Value = office.LocationId };
                var taskResult = context.Database.SqlQuery<decimal>("[dbo].[Office_Create] @Name, @Description, @LocationId", officeName, officeDescription, officeLocationId).FirstAsync();
                return Convert.ToInt32(taskResult.Result);
            }
        }

        public void Update(OfficeDto office)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var officeName = new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = office.Name };
                var officeDescription = new SqlParameter { ParameterName = "@Description", SqlDbType = SqlDbType.VarChar, Value = office.Description };
                var officeLocationId = new SqlParameter { ParameterName = "@LocationId", SqlDbType = SqlDbType.Int, Value = office.LocationId };
                var officeId = new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = office.Id };
                context.Database.ExecuteSqlCommand("[dbo].[Office_Update] @Name, @Description, @LocationId, @Id", officeName,
                    officeDescription, officeLocationId, officeId);
            }
        }

        public void Delete(int officeId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var officeIdParam = new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = officeId };
                context.Database.ExecuteSqlCommand("DELETE FROM Offices WHERE Id = @Id", officeIdParam);
            }
        }
    }

}
