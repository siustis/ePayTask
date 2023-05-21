# Run instructions
I have added the task solutions in 2 parts: for the first task ePay.Denominations - a console app. For the 2nd task ePay.Api - web API for the REST server and ePay.Simulator - a console app that makes the required requests.

To run the project for the first task:
 1. Set ePay.Denominations as startup project.
 2. Run the project.

To run the project for the second task:
1. In package manager console run the command 'Update-Database'.
2. In ePay.Simulator check line 10 and update the port to match the one in ePay.Api's launchSettings.json.
3.  Set as startup projects ePay.Simulator(add it in the first position to see the console with output) and ePay.Api.
4.  Run the project.

# Implementation details

 - Used SQL Server as a database, so you will need a local installation to run.
 - Used a composite key for the sorted position requirement, however as far as I know the row ordering is dependent on the DBMS so we might need to look for alternative solutions.
 