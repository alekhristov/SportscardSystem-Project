﻿using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ICompanyService
    {
        /// <summary>
        /// Gets all companies registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICompanyDto> GetAllCompanies();

        /// <summary>
        /// Adds a new company to the database
        /// </summary>
        /// <param name="company"></param>
        void AddCompany(ICompanyDto companyDto);

        /// <summary>
        /// Deletes a specified company from the database 
        /// </summary>
        /// <param name="company"></param>
        void DeleteCompany(string companyName);

        /// <summary>
        /// Gets the company with the most visits
        /// </summary>
        /// <returns></returns>
        ICompanyDto GetMostActiveCompany();

        /// <summary>
        /// Gets the most favourite sportshall for a given company.
        /// </summary>
        /// <param name="companyName">Company's name</param>
        /// <returns></returns>
        ISportshallDto GetCompanysFavouriteSportshall(string companyName);
    }
}
