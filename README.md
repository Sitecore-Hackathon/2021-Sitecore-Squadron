![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2021

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
- [Starter kit instructions](STARTERKIT_INSTRUCTIONS.md)
  

## Team name

Sitecore Squadron

## Category

The best enhancement of SXA

## Description

Module Purpose

To give the ability for Content Authors to select a rendering variant that will localize the way the data is presented to the user based on the user's location.

What was solved?

Content Authors will not have to think twice to determine what rendering variant to choose for display in a particular region. Simply choose the Localize variant, and our module will take care of the rest.

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)

## Installation instructions

1. Start docker environment using `.\Start-Hackathon.ps1`
2. Open solution in Visual Studio and build the solution.
3. You have options on what to do next. We will provide two packages to install: 1) a package that contains simply the template items you need to create content and 2) a package that contains the template items AND sample content items. We recommend you install the latter.
4. Publish the site.

## Usage instructions

If you installed the sample content package, you can skip Steps 1-8 completely. The sample content package will come with examples already created.

1. Insert a Localized Rendering Variants Settings under the Presentation node found within the SXA site.

![Localized Rendering Variants Settings](docs/images/insertingLocalizedRenderingVariantsSettings.PNG?raw=true "Localized Rendering Variants Settings")

2. In this newly created item, insert a Localized Rendering Variants Setting item. Name it the name of the rendering variant definition you want to define localization options for.

![Localized Rendering Variants Setting](docs/images/insertingLocalizedRenderingVariantsSetting.PNG?raw=true "Localized Rendering Variants Setting")

3. On this newly created Localized Rendering Variant Setting item, fill the Rendering Variant Definition field with the Rendering Variant Definition you want to mess around with. Then save the item. After doing so, the available rendering variants will appear for the Fallback Variant field. This Fallback Variant field will be used when either a) a user's location cannot be resolved or b) the user's location is not within a certain distance away from a particular region to receive its localized version. Also be sure to update the distance in km how far away the user can be from the various locations in order for that location's variant to be shown.

![Setting Rendering Variant Definition Selection](docs/images/settingRenderingVariantDefinitionSelection.PNG?raw=true "Setting Rendering Variant Definition Selection")

4. Underneath the Localized Rendering Variant Setting item, insert a Coordinate Rule item. Here you define the longitude and latitude that the user must be within xxx distance of. Then define the variant you want displayed if the user is indeed within the xxx distance of the geolocation. Continue to create more Coordinate Rules if you want to define more areas to have different variants displayed.

![Coordinate Rule Example](docs/images/coordinateRuleExample.PNG?raw=true "Coordinate Rule Example")

5. Be sure to go to the rendering variant definition of the component you are specifying Localization settings for and insert our custom Localize variant. It is an insert option on the rendering variant definition.

![Localize Insert Rule](docs/images/localizeInsertRule.PNG?raw=true "Localize Insert Rule")

6. Open the Home page in the Experience Editor. Insert a component that has a Localized Rendering Variant Setting item created for it. Then select the Localized variant. Save. Publish site. 

![Select Localize](docs/images/selectLocalize.PNG?raw=true "Select Localize")

8. Navigate to the home page in the CD. The Home page should display the fallback variant of the components displayed since no location is specified. Add a query string with the params "lat" and "lng". Use the latitude and longitude values found on one of the Coordinate Rules items for that component. When the page loads, the component will be displayed using the variant specified in the Coordinate Rule instead of the selected fallback variant. An example of the query string looks like this: https://cm.sitecoresquadron.localhost/?lat=28.6448&lng=77.216721.
