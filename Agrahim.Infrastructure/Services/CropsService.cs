using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.DTOs;
using Agrahim.Common.ViewModels.Crops;
using Agrahim.Domain.ServicesContracts;
using Agrahim.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.Infrastructure.Services
{
    public class CropsService : ICropsService
    {
        private readonly AgrahimContext _agrahimContext;

        public CropsService(AgrahimContext agrahimContext)
        {
            _agrahimContext = agrahimContext;
        }

        public async Task<IEnumerable<CropDto>> GetAll(CancellationToken ct = default)
        {
            var result = await _agrahimContext.Crops.Select(cr => new CropDto
            {
                Id = cr.Id,
                Name = cr.Name,
                CropsTypeName = cr.CropsType.Name,
                IsRemoved = cr.IsRemoved
            }).ToListAsync(ct);

            return result;
        }

        public async Task<IEnumerable<CropsTypeToSelectDto>> GetCropsTypeToSelect(CancellationToken ct = default)
        {
            var result = await _agrahimContext.CropsTypes
                .Where(ct => ct.IsRemoved == false)
                .OrderBy(ct => ct.NormalizedName)
                .Select(ct => new CropsTypeToSelectDto
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync(ct);

            return result;
        }

        public async Task<bool> IsUniq(string name, CancellationToken ct = default)
        {
            var cropEntity = await _agrahimContext.Crops
                .FirstOrDefaultAsync(entity => entity.NormalizedName == name.ToUpper(), ct);
            return cropEntity == default;
        }

        public async Task Create(CreateCropViewModel model, CancellationToken ct = default)
        {
            var cropEntity = new CropEntity
            {
                Name = model.Name,
                CropsTypeId = model.CropsTypeId
            };

            await _agrahimContext.Crops.AddAsync(cropEntity, ct);
            await _agrahimContext.SaveChangesAsync(ct);
        }
    }
}