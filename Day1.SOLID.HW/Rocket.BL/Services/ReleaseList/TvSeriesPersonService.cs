using System.Linq;
using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.UoW;

namespace Rocket.BL.Services.ReleaseList
{
    public class TvSeriesPersonService : BaseService, ITvSeriesPersonService
    {
        public TvSeriesPersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public TvSeriesPersonsDto GetPersons(int id)
        {
            var tvSeries = _unitOfWork.TvSeriasRepository
                .GetById(id);

            if (tvSeries == null)
            {
                return null;
            }

            tvSeries.ListPerson = _unitOfWork.PersonRepository
                .Get(
                    f => f.ListTvSerias.Select(t => t.Id).Contains(id),
                    includeProperties: $"{nameof(PersonEntity.PersonType)}").ToList();

            return Mapper.Map<TvSeriesPersonsDto>(tvSeries);
        }
    }
}
