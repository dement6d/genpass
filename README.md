<h1 align="center">genpass</h1>
<p align="center">A lightweight, simple and easy to use password generator<br>
<a href="https://snipesharp.xyz/donate">Support this project</a></p>

# Examples
- See all possible arguments
  - `genpass -h`
- Generate a long password that won't execute any unwanted commands when pasted in the Terminal:
  - ```genpass -e \!\&\(\)\$\?\;\\\*\'\"\`\<\> -l 50```
- Generate a password out of lower case letters only:
  - ```genpass -c qwertyuiopasdfghjklzxcvbnm```
- Append a password to a text file
  - ```genpass -o password.txt```

# Installing
- Clone the repository
- Run the appropriate installation script
- You can now run the `genpass` command in your Terminal or if on Windows, you have a shortcut on your Desktop
