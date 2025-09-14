using System.ComponentModel.DataAnnotations;

namespace RestaurantProject.Application.Settings;
public class MailSettings
{
	[Required, EmailAddress]
	public string Mail { get; set; } = string.Empty;
	[Required]
	public string DisplayName { get; set; } = string.Empty;
	[Required]
	public string Password { get; set; } = string.Empty;
	[Required]
	public string Host { get; set; } = string.Empty;
	[Range(100, 999)]
	public int Port { get; set; }
}
