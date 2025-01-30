const fs = require("fs");
const path = require("path");

const targetConnectionString = "Data Source=.;Initial Catalog=Jada30_Identity; User ID=sa;Password=P@ssw0rd;Integrated Security=False;Trust Server Certificate=True;Encrypt=False";

const files = [
  "E:\\Jada\\Jada\\Common\\Shared\\DataBaseLayer\\Infrastructure\\Infrastructure\\Data\\DesignTimeDbContextFactory.cs",
  "E:\\Jada\\Jada\\Common\\Shared\\DataBaseLayer\\Infrastructure\\Infrastructure\\Data\\Jada30Context.cs",
  "E:\\Jada\\Jada\\Services\\Identity\\Identity.Api\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\IdentityServer4\\IdentityServer4.API\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\Jada30Core\\Jada30Core.Api\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\Lookups\\Lookups.API\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\Identity\\Identity.Api\\appsettings.json",
];

files.forEach((filePath) => {
  try {
    // Read JSON file
    const fileContent = fs.readFileSync(filePath, "utf8");
    const jsonData = JSON.parse(fileContent);

    // Check if "ConnectionStrings" exists
    if (jsonData.ConnectionStrings && jsonData.ConnectionStrings.Default) {
      jsonData.ConnectionStrings.Default = targetConnectionString;

      // Write updated JSON back to file
      fs.writeFileSync(filePath, JSON.stringify(jsonData, null, 4), "utf8");

      console.log(`Updated connection string in: ${filePath}`);
    } else {
      console.log(`No "ConnectionStrings" found in: ${filePath}`);
    }
  } catch (error) {
    console.error(`Error processing file ${filePath}:`, error);
  }
});
