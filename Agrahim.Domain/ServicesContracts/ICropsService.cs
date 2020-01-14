using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.DTOs;
using Agrahim.Common.ViewModels.Crops;

namespace Agrahim.Domain.ServicesContracts
{
    public interface ICropsService
    {
        Task<IEnumerable<CropDto>> GetAll(CancellationToken ct = default);

        Task<IEnumerable<CropsTypeToSelectDto>> GetCropsTypeToSelect(CancellationToken ct = default);

        Task<bool> IsUniq(string name, CancellationToken ct = default);

        Task Create(CreateCropViewModel model, CancellationToken ct = default);
    }
}