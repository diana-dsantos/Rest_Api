# Rocket-Elevators-Rest-API

This repo serves as the Rocket Elevators REST API developed for CodeBoxx's week 8 of the Odyssey program. We were tasked with developing a REST API to interact with the MYSQL database that already exists, and provide the appropriate requests for queries.

The queries for the REST API are found in a public PostMan workspace at: https://app.getpostman.com/join-team?invite_code=f09613b7a24e69fef5524a5d3f5f434e&ws=1c76f8ec-a244-4f00-9317-ee95973e1306

The REST API URL is: https://week-8-restapi-apibehavioroptions-kaelenburroughs.azurewebsites.net/

Each request works as follows:

1. GET Batteries - Returns the information for a specific battery, and different batteries can be returned by changing the number at the end of the API request.

2. GET Batteries Status - Returns the current status of the queried battery.

3. PUT Batteries Status - Changes the status of the queried battery to either 'Active', 'Inactive', or 'Intervention'.

4. GET Columns - Returns the information for a specific column, and different columns can be returned by changing the number at the end of the API request.

5. GET Columns Status - Returns the current status of the queried column.

6. PUT Columns Status - Changes the status of the queried column to either 'Active', 'Inactive', or 'Intervention'.

7. GET Elevators - Returns the information for a specific elevator, and different elevators can be returned by changing the number at the end of the API request.

8. GET Elevators Status - Returns the current status of the queried elevator.

9. PUT Elevators Status - Changes the status of the queried elevator to either 'Active', 'Inactive', or 'Intervention'.

10. GET Elevators List Not Active - Returns a list of elevators that do not have a status of 'Active'.

11. GET Buildings List Intervention - Returns a list of all the buildings that have a battery, column, or elevator with a status of 'Intervention'.

12. Get Leads (all) - Returns a list of all the leads in the database.

13. GET Leads (Last 30 Days) - Returns a list of all leads submitted in the last 30 days, where the submitted lead is not also linked to a customer.
