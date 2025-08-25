using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Application.Contracts.MenuItem;
public record MenuItemResponse(
	int Id,
	string Name,
	string Description,
	decimal Price,
	bool IsActive
	);
