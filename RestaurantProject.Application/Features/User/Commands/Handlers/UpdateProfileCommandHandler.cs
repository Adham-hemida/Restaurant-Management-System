using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Application.Features.User.Commands.Handlers;
public class UpdateProfileCommandHandler (IUserService userService) : IRequestHandler<UpdateProfileCommand, Result>
{
	private readonly IUserService _userService = userService;
	public async Task<Result> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
	{
		return await _userService.UpdateProfileAsync(request.UserId, request.UpdateProfileRequest);
	}
}
