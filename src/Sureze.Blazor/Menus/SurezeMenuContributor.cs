﻿using System.Threading.Tasks;

using Sureze.Localization;
using Sureze.MultiTenancy;

using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Sureze.Blazor.Menus;

public class SurezeMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<SurezeResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                SurezeMenus.Home,
                l["Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddGroup(
                new ApplicationMenuGroup(
                    name: "Patients",
                    displayName: l["Patients"]
                )
            );

        context.Menu.AddItem(
            new ApplicationMenuItem("Patients", l["Patients"], groupName: "Patients", icon: "fas fa-hospital")
                .AddItem(new ApplicationMenuItem(
                    name: "PatientsList",
                    displayName: l["Patients List"],
                    url: "/Patients")
                ).AddItem(new ApplicationMenuItem(
                    name: "RegisterPatient",
                    displayName: l["Register Patient"],
                    url: "/RegisterPatient")
                 )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
