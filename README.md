# Beer-Tap-Challenge
Beer Tap Challenge

# What's on Tap?
iQmetrix is a pretty cool place to work... we have a beer tap?!?!  No bullshit!  In fact, each office has at least one tap, most have more!  A great way to drive home the benefits of hypermedia and to build a RESTful API that means something to every iQer is to create a hypermedia API to track “what’s on tap” in the various iQ offices and what happens to a keg as we pour off pint after delicious pint.
Requirements:
We have 5.5 offices: Vancouver, Regina, Winnipeg, Davidson (NC), Manila Philippines, Sydney Australia (0.5... one person there)
Each office may have 1 or more beer taps.
Need to be able to find out what is on tap at a particular office
Need to be able to change what’s on tap at a particular office
Track usage of beer so you can have some state transitions:
New Keg has X ml of beer
Each glass you POST would take Y ml out
As the beer nears the bottom, consider the different states that may be appropriate.  New --> GoinDown --> AlmostEmpty --> SheIsDryMate, etc.  Be creative in your naming.  It's more funner!
If the Keg is New or GoinDown, you wouldn’t have a link to “ReplaceKeg”.  If it’s AlmostEmpty or Dry, then a link to “replaceKeg” would be there
If the Keg is Dry, no hypermedia to POST a new glass, probably just one to “replaceKeg”.
Using our hypermedia framework and Visual Studio API Template, create an API and some sort of User Interface/client (console app will be fine).
