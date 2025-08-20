using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Domain.Entites;
[Owned]
public class RefreshToken
{
	public string Token { get; set; } = string.Empty;

	public DateTime ExpiresOn { get; set; }

	public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

	public DateTime? RevokedOn { get; set; }


	public bool IsExpired => DateTime.UtcNow >= ExpiresOn;

	public bool IsActive => RevokedOn == null && !IsExpired;


}