# Unit test controller logic in ASP.NET Core

Unit tests involve testing a part of an app in isolation from its infrastructure and dependencies. When unit testing controller logic, only the contents of a single action are tested, not the behavior of its dependencies or of the framework itself.

## Unit Testing Controllers

Set up unit tests of controller actions to focus on the controller's behavior. A controller unit test avoids scenarios such as filters, routing, and model binding. Tests that cover the interactions among components that collectively respond to a request are handled by integration tests. For more information on integration tests, see Integration tests in ASP.NET Core.

If you're writing custom filters and routes, unit test them in isolation, not as part of tests on a particular controller action.

# Best Practice

## Patterns

- Strategy
- Adapter
- MVC
- Specification

ASP.NET MVC (Model-View-Controller architectural pattern)

### SOLID and MVC

- Model
- View
- Controller

What are the single responsiblities of each of these elements in MVC

## Model

- Business logic should be in the Model only Before start code on MVC we should make understand that Business logic should be reside in Model only

- Create separate assembly/Library for the Model if the Enterprise application is large and complex then make separate assembly for Model to avoid any mishap Big Ball of Mud or Spaghetti code. Basically Model should contain business logic, Validation part, session maintenance and data logic part.

### Onion Architecture

![Clean Architecture](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)

[The Clean Code Blog by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

[Martin Fowler on Domain Driven Design](https://martinfowler.com/tags/domain%20driven%20design.html)

[Martin Fowler Domain Model](https://martinfowler.com/eaaCatalog/domainModel.html)

### Layering Domain Driven Design

![Layering of Domain Driven Design](https://github.com/Onemanwolf/Controller_Unit_Testing/blob/master/How_Session/images/DDDLayers.png?raw=true 'Request Pipeline')



Domain Model or Domain Driven Design is a good example to follow.

Domain Model for example Orders Domain will have all business logic factories/builders all code will reference the Domain model to get DTO, Models and Validation from the Domain Model.

- We can place Application services to build the model or to implement the model to build the ViewModel or View by retrieving data we need from Repository and getting domain object form Domain layer.


### Patterns, Principles and Practices of Domain Driven Design by Scott Millet with Nick Tune.
![Scott Millet with Nick Tune](https://github.com/Onemanwolf/Controller_Unit_Testing/blob/master/How_Session/images/MVCDDD.png?raw=true 'Request Pipeline')


### Layers Detail.
![Scott Millet with Nick Tune](https://github.com/Onemanwolf/Controller_Unit_Testing/blob/master/How_Session/images/OnionLayersDetail.png?raw=true 'Request Pipeline')
## Getting Started exercise

To demonstrate controller unit tests, review the following controller in the sample app.

[Clone Code](https://github.com/Onemanwolf/Controller_Unit_Testing)

The Home controller displays a list of brainstorming sessions and allows the creation of new brainstorming sessions with a POST request:

```C#
        public class HomeController : Controller
{
    private readonly IBrainstormSessionRepository _sessionRepository;

    public HomeController(IBrainstormSessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<IActionResult> Index()
    {
        var sessionList = await _sessionRepository.ListAsync();

        var model = sessionList.Select(session => new StormSessionViewModel()
        {
            Id = session.Id,
            DateCreated = session.DateCreated,
            Name = session.Name,
            IdeaCount = session.Ideas.Count
        });

        return View(model);
    }

    public class NewSessionModel
    {
        [Required]
        public string SessionName { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> Index(NewSessionModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            await _sessionRepository.AddAsync(new BrainstormSession()
            {
                DateCreated = DateTimeOffset.Now,
                Name = model.SessionName
            });
        }

        return RedirectToAction(actionName: nameof(Index));
    }
}
```

The preceding controller:

Follows the Explicit Dependencies Principle.
Expects dependency injection (DI) to provide an instance of IBrainstormSessionRepository.
Can be tested with a mocked IBrainstormSessionRepository service using a mock object framework, such as Moq. A mocked object is a fabricated object with a predetermined set of property and method behaviors used for testing. For more information, see Introduction to integration tests.

The HTTP GET Index method has no looping or branching and only calls one method. The unit test for this action:

- Mocks the IBrainstormSessionRepository service using the GetTestSessions method. GetTestSessions creates two mock brainstorm sessions with dates and session names.

- Executes the Index method.

* Makes assertions on the result returned by the method
  - A ViewResult is returned.
  - The ViewDataDictionary.Model is a StormSessionViewModel.
  - There are two brainstorming sessions stored in the ViewDataDictionary.Model.

You can create a
method to Get Sessions that returns a list BrainstormSession as demonstrated below

```C#
       private List<BrainstormSession> GetTestSessions()
{
   var sessions = new List<BrainstormSession>();
   sessions.Add(new BrainstormSession()
   {
       DateCreated = new DateTime(2016, 7, 2),
       Id = 1,
       Name = "Test One"
   });
   sessions.Add(new BrainstormSession()
   {
       DateCreated = new DateTime(2016, 7, 1),
       Id = 2,
       Name = "Test Two"
   });
   return sessions;
}
```

```C#
        [Fact]
public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
{
    // Arrange
    var mockRepo = new Mock<IBrainstormSessionRepository>();
    mockRepo.Setup(repo => repo.ListAsync())
        .ReturnsAsync(GetTestSessions());
    var controller = new HomeController(mockRepo.Object);

    // Act
    var result = await controller.Index();

    // Assert
    var viewResult = Assert.IsType<ViewResult>(result);
    var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
        viewResult.ViewData.Model);
    Assert.Equal(2, model.Count());
}
```

You can create a
method to Get Sessions that returns a list BrainstormSession as demostrated below

```C#
       private List<BrainstormSession> GetTestSessions()
{
   var sessions = new List<BrainstormSession>();
   sessions.Add(new BrainstormSession()
   {
       DateCreated = new DateTime(2016, 7, 2),
       Id = 1,
       Name = "Test One"
   });
   sessions.Add(new BrainstormSession()
   {
       DateCreated = new DateTime(2016, 7, 1),
       Id = 2,
       Name = "Test Two"
   });
   return sessions;
}
```

But we know a better way to do the same thing and will not have to maintain the creation as we would in the above example.
