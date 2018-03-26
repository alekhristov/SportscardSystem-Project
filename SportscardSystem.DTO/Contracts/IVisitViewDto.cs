﻿using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface IVisitViewDto
    {
        /// <summary>
        /// Visit's unique id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Visit's sporthall name
        /// </summary>
        string SportshallName { get; }

        /// <summary>
        /// Visit's sport name
        /// </summary>
        string SportName { get; }

        /// <summary>
        /// Visit's date
        /// </summary>
        DateTime CreatedOn { get; set; }
    }
}
