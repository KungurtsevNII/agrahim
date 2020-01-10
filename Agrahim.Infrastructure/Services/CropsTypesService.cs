using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.DTOs;
using Agrahim.Common.ViewModels;
using Agrahim.Domain.ServicesContracts;
using Agrahim.Infrastructure.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.Infrastructure.Services
{
    public class CropsTypesService : ICropsTypesService
    {
        private readonly AgrahimContext _agrahimContext;
        private readonly IMapper _mapper;

        public CropsTypesService(AgrahimContext agrahimContext, IMapper mapper)
        {
            _agrahimContext = agrahimContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CropsTypeDto>> GetAll(CancellationToken ct = default)
        {
            var result = await _agrahimContext.CropsTypes
                .ProjectTo<CropsTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);
            return result;
        }

        public async Task Create(string name, CancellationToken ct = default)
        {
            var entity = new CropsTypeEntity
            {
                Name = name,
            };
            
            await _agrahimContext.CropsTypes.AddAsync(entity, ct);
            await _agrahimContext.SaveChangesAsync(ct);
         }

        public async Task<bool> IsUniq(string name, CancellationToken ct = default)
        {
            var cropsTypeEntity = await _agrahimContext.CropsTypes
                .FirstOrDefaultAsync(entity => entity.NormalizedName == name.ToUpper(), ct);
            return cropsTypeEntity == default;
        }

        public async Task Disable(long id, CancellationToken ct = default)
        {
            var cropsType = await _agrahimContext.CropsTypes
                .FindAsync(id);

            if (cropsType is null)
            {
                return;
            }

            cropsType.IsRemoved = true;
            await _agrahimContext.SaveChangesAsync(ct);
        }

        public async Task<UpdateCropsTypeViewModel> GetById(long id, CancellationToken ct = default)
        {
            var result = await _agrahimContext.CropsTypes
                .ProjectTo<UpdateCropsTypeViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct => ct.Id == id, ct);

            return result;
        }
    }
}