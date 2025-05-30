const fs = require("fs");
const path = require("path");

const targetConnectionString = "Data Source=.;Initial Catalog=Jada30_Identity; User ID=sa;Password=WsmWsm2@22;Integrated Security=False;Trust Server Certificate=True;Encrypt=False";

const files = [
  "C:\Users\AhmadMuhammadKhadrah\source\repos\Jada30\Services\Jada30Core\Jada30Core.Application\appsettings.json",
  "E:\\Jada\\Jada\\Common\\Shared\\DataBaseLayer\\Infrastructure\\Infrastructure\\Data\\Jada30Context.cs",
  "E:\\Jada\\Jada\\Services\\Identity\\Identity.Api\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\IdentityServer4\\IdentityServer4.API\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\Jada30Core\\Jada30Core.Api\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\Lookups\\Lookups.API\\appsettings.json",
  "E:\\Jada\\Jada\\Services\\Identity\\Identity.Api\\appsettings.json",
];

const updateJsonFile = (filePath) => {
  try {
    const fileContent = fs.readFileSync(filePath, "utf8");
    const jsonData = JSON.parse(fileContent);

    if (jsonData.ConnectionStrings && jsonData.ConnectionStrings.Default) {
      jsonData.ConnectionStrings.Default = targetConnectionString;
      fs.writeFileSync(filePath, JSON.stringify(jsonData, null, 4), "utf8");
      console.log(`Updated JSON connection string in: ${filePath}`);
    } else {
      console.log(`No "ConnectionStrings" found in JSON: ${filePath}`);
    }
  } catch (error) {
    console.error(`Error processing JSON file ${filePath}:`, error);
  }
};

const updateCsFile = (filePath) => {
  try {
    let fileContent = fs.readFileSync(filePath, "utf8");

    const regex = /Data Source=[^;]+;[^"]+/g;

    if (regex.test(fileContent)) {
      fileContent = fileContent.replace(regex, targetConnectionString);
      fs.writeFileSync(filePath, fileContent, "utf8");
      console.log(`Updated C# connection string in: ${filePath}`);
    } else {
      console.log(`No hardcoded connection string found in C# file: ${filePath}`);
    }
  } catch (error) {
    console.error(`Error processing C# file ${filePath}:`, error);
  }
};

files.forEach((filePath) => {
  if (!fs.existsSync(filePath)) {
    console.log(`File not found: ${filePath}`);
    return;
  }

  const ext = path.extname(filePath).toLowerCase();

  if (ext === ".json") {
    updateJsonFile(filePath);
  } else if (ext === ".cs") {
    updateCsFile(filePath);
  } else {
    console.log(`Skipping unsupported file type: ${filePath}`);
  }
});
