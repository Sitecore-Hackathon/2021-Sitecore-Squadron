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
2. Open solution in Visual Studio and run build on the solution
3. Use the Sitecore Installation wizard to install the [package](#link-to-package)
4. ...
5. profit

## Usage instructions

1. Insert a Localized Rendering Variants Settings under the Presentation node found within the SXA site.

![Inserting Localized Rendering Variants Settings](docs/images/insertingLocalizedRenderingVariantsSettings.png?raw=true "Inserting Localized Rendering Variants Settings")

2. In this newly created item, insert a Localized Rendering Variants Setting item. Name it the name of the rendering variant definition you want to define localization options for.

![Inserting Localized Rendering Variants Setting](docs/images/insertingLocalizedRenderingVariantsSetting.png?raw=true "Inserting Localized Rendering Variants Setting")

3. On this newly created Localized Rendering Variant Setting item, fill the Rendering Variant Definition field with the Rendering Variant Definition you want to mess around with. Then save the item. After doing so, the available rendering variants will appear for the Fallback Variant field. This Fallback Variant field will be used when either a) a user's location cannot be resolved or b) the user's location is not within a certain distance away from certain locations to receive the localized variant for a particular region.

![Selecting Rendering Variant Definition To Localize](docs/images/selectingRenderingVariantDefinitionToLocalize.png?raw=true "Selecting Rendering Variant Definition To Localize")