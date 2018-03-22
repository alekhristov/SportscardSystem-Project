﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddClientCommand : Command, ICommand
    {
        private IClientService clientService;
        private ICompanyService companyService;
        private readonly IValidateCore coreValidator;

        public AddClientCommand(ISportscardFactory sportscardFactory, IClientService clientService, ICompanyService companyService, IValidateCore coreValidator) : base(sportscardFactory)
        {
            this.clientService = clientService ?? throw new ArgumentNullException("Client service can not be null!"); ;
            this.companyService = companyService ?? throw new ArgumentNullException("Company service can not be null!"); 
            this.coreValidator = coreValidator ?? throw new ArgumentNullException("Validator can't be null");
        }

        public string Execute(IList<string> parameters)
        {
            string clientFirstName = parameters[0];
            string clientLastName = parameters[1];
            int? clientAge;
            string companyName;
            Guid companyId;
            //
            Guard.WhenArgument(parameters.Count, "Parameters count.").IsGreaterThan(4).Throw();
            Guard.WhenArgument(clientFirstName, "Client first name.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(clientLastName, "Client last name.").IsNullOrEmpty().Throw();
            //1 Validation command lenght 
            if (parameters.Count == 3)
            {
                companyName = parameters[2];
                clientAge = null;
            }
            else
            {
                clientAge = this.coreValidator.IntFromString(parameters[2], "Client's age.");
                Guard.WhenArgument(clientAge, "Clients Age.").IsNull().Throw();
                this.coreValidator.ClientAgeValidation(clientAge, "Client's age");
                companyName = parameters[3];
                
            } 
            Guard.WhenArgument(companyName, "Company Name").IsNullOrEmpty().Throw();
            companyId = this.clientService.GetCompanyGuidByName(companyName);

            IClientDto client = this.SportscardFactory.CreateClientDto(clientFirstName, clientLastName, clientAge, companyId);
            Guard.WhenArgument(client, "Client DTO").IsNull().Throw();
            this.clientService.AddClient(client);

            return $"\"{clientFirstName} {clientLastName}\" client was added to database.";
        }
    }
}