using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.DTOs;
using Agrahim.Common.ViewModels;

namespace Agrahim.Domain.ServicesContracts
{
    public interface ICropsTypesService
    {
        Task<IEnumerable<CropsTypeDto>> GetAll(CancellationToken ct = default);

        Task Create(string name, CancellationToken ct = default);

        Task<bool> IsUniq(string name, CancellationToken ct = default);

        Task Disable(long id, CancellationToken ct = default);

        Task<UpdateCropsTypeViewModel> GetById(long id, CancellationToken ct = default);
    }
}