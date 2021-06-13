CREATE PROCEDURE [dbo].[Signin]
	@Name nvarchar(50),
	@Password nvarchar(50),
	@ConfirmPassword nvarchar(50),
	@Email nvarchar(50)
AS
	Insert into LoginInfo(Name,Password,ConfirmPassword,Email) values(@Name, @Password,@ConfirmPassword,@Email)
RETURN 0
