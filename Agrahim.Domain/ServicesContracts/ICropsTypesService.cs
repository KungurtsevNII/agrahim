using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.DTOs;
using Agrahim.Common.ViewModels;
using Agrahim.Common.ViewModels.CropsType;

namespace Agrahim.Domain.ServicesContracts
{
    public interface ICropsTypesService
    {
        Task<IEnumerable<CropsTypeDto>> GetAll(CancellationToken ct = default);

        Task Create(CreateCropsTypeViewModel model, CancellationToken ct = default);

        Task<bool> IsUniq(string name, CancellationToken ct = default);

        Task Disable(long id, CancellationToken ct = default);

        Task<UpdateCropsTypeViewModel> GetById(long id, CancellationToken ct = default);

        Task Update(UpdateCropsTypeViewModel model, CancellationToken ct = default);
    }
}