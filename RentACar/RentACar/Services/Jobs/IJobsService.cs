﻿using RentACar.Models;

namespace RentACar.Services.Jobs
{
    public interface IJobsService
    {
        Task Create(Job newJob);

        Guid getJobIdByTitle(string title);
    }
}