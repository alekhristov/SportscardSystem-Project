﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;
using System;
using System.Linq;

namespace SportscardSystem.Logic.Services
{
    public class SportscardService : ISportscardService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public SportscardService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddSportscard(ISportscardDto sportscardDto)
        {
            Guard.WhenArgument(sportscardDto, "SportscardDto can not be null").IsNull().Throw();

            var sportscardToAdd = this.mapper.Map<Sportscard>(sportscardDto);

            if (!this.dbContext.Sportscards.Any(s => s.ClientId == sportscardDto.ClientId && s.CompanyId == sportscardDto.CompanyId))
            {
                this.dbContext.Sportscards.Add(sportscardToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A Sportscard with the current ClientId and CompanyId alreadu exists!");
            }
        }

        //To be implemented
        public void DeleteSportscard(ISportscardDto sportscardDto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ISportscardDto> GetAllSportscards()
        {
            var allSportscards = dbContext.Sportscards.ProjectTo<SportscardDto>();
            Guard.WhenArgument(allSportscards, "AllSportscards can not be null").IsNull().Throw();

            return allSportscards;
        }
    }
}