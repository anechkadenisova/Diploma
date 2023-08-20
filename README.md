# OrangeHRM
This is the solution with UI tests for https://opensource-demo.orangehrmlive.com/ 

OrangeHRM offers a comprehensive HR management system to suit all of your business HR needs which can also be customized according to your requirements.

## Tech Stack

Test framework: *NUnit*

Logging: *NLog*

Reporting: *Allure*

Browser automation: *Selenium*

## Approaches used in the development of the framework and tests

* Browser
* Page Object
* Page Steps
* Builder for model

## Test Set
**Login Tests**
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| Login_StandartUser  | Positive | Try to sign in using valid login/password  |
| LoginFailTest  | Negative | Try to sign in using fail login/password, check alert message |

**Job Tests**
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| Add Job | Positive | Try to add new Job "Admin"  |
| Change Job | Positive | Try to change job Admin - add file .txt |
| Delete Job  | Positive | Try to delete job Admin |
| Repeat Job  | Negative | Fail on repeating name of job: "Finance Manager", check alert message |

**Leave Tests**
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| MyLeaveList  | Positive | Try to add comment in MyLeave page: "OK", check successfully message |
| CheckComments  | Positive | Check added comment in MyLeave page |

**Entitlement Tests**
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| AddLeaveEntitlement  | Positive | Try to add Leave Entitlement with Multiple Employees |

## Installation
1. Clone repository OrangeHRM tests - [Diploma](https://github.com/anechkadenisova/Diploma) repository.

2. Open solution in Visual studio (or other for C#).

3. Create solution build configurations Debug. 

4. Edit BrowserSetup.runsettings and set your values.
   
5. Buid solution and run tests.

6. Congratulations!

## Run Tests

For run test using .NET CLI, run the following command
```bash
   Dotnet test
```

## Generate Allure report
Firstly save a path where running tests data for a report saved.

 - Download and extract Allure.
 - Open folder with Allure bin, for example Х:\Allure\allure-x.xx.x\bin.
 - Run CMD in this folder.
 - Run command
 ```bash
   allure serve
```
- Allure report will be opened in your web browser.

## Authors
- [@Anna Denisova](https://github.com/anechkadenisova)
