namespace CinemaCity.Web.Infrastructure.Extensions
{
	using Data.Models;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;

	using static Common.WebConstants;

	public static class WebBuilderExtensions
	{
		public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
		{
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;
			UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			RoleManager<IdentityRole> roleManager =
				serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			Task.Run(async () =>
				{
					if (await roleManager.RoleExistsAsync(AdminRoleName))
					{
						return;
					}

					IdentityRole role = new IdentityRole(AdminRoleName);

					await roleManager.CreateAsync(role);

					ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

					await userManager.AddToRoleAsync(adminUser, AdminRoleName);
				})
				.GetAwaiter()
				.GetResult();

			return app;
		}
	}
}
