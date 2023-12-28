﻿using RandomNameGeneratorLibrary;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Sureze;

public class PatientsDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Patient, Guid> _patientsRepository;
    private readonly IGuidGenerator _guidGenerator;
    private Random _rnd = new Random();

    public PatientsDataSeederContributor(IRepository<Patient, Guid> patientsRepository, IGuidGenerator guidGenerator)
    {
        _patientsRepository = patientsRepository;
        _guidGenerator = guidGenerator;
    }

    [UnitOfWork]
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _patientsRepository.GetCountAsync() > 0)
        {
            return;
        }

        var personGenerator = new PersonNameGenerator();

        int cumberOfSeededPatients = 5000;

        List<Patient> patients = new(5000);

        for (int i = 0; i < cumberOfSeededPatients; i++)
        {
            string firstName = personGenerator.GenerateRandomFirstName();
            Race race = GetRandomEnumValue<Race>();
            bool citizen = _rnd.Next() != 1;

            Patient patient = new(id: _guidGenerator.Create(), firstName, race, citizen)
            {
                Nationality = GetRandomEnumValue<Country>(),
                AlternateIdNumber = _rnd.Next(int.MaxValue).ToString(),
                LastName = personGenerator.GenerateRandomLastName(),
                Language = GetRandomEnumValue<Language>(),
                MaritalStatus = GetRandomEnumValue<MaritalStatus>(),
                Ethnicity = GetRandomEnumValue<Ethnicity>(),
                EducationLevel = GetRandomEnumValue<EducationLevel>(),
                DateOfBirth = GenerateRandomDateTime(),
                AlternateIdType = GetRandomEnumValue<AlternateIdType>(),
                NationalIdNumber = _rnd.Next(int.MaxValue).ToString(),
                PatientCategory = "",
                Religion = GetRandomEnumValue<Religion>(),
                Sex = GetRandomEnumValue<Sex>(),
                Title = GetRandomEnumValue<Title>()

            };

            patients.Add(patient);
        }

        await _patientsRepository.InsertManyAsync(patients, autoSave: true);
    }

    private T GetRandomEnumValue<T>() where T : struct, Enum
    {
        var enumCount = Enum.GetNames<T>().Length;

        int randomN = _rnd.Next(1, enumCount);

        return (T)(object)randomN;
    }

    private DateTime GenerateRandomDateTime()
    {
        DateTime start = new DateTime(1960, 1, 1);
        int days = 50 * 12 * 30; // number od days: years * months * days
        return start.AddDays(_rnd.Next(days));
    }
}