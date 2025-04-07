# YorkCodeDojo - The Gilded Rose

This is an exercise in handling changes in a legacy code base. Where legacy can mean a mix of low quality or missing automated tests, or poorly structured code and often both.

Have a read of the instruction given to you by your new employer to help add a new feature to stock management system at the Gilded Rose inn;

[Gilded Rose Requirements](GildedRoseRequirements.md)

## Your task
Your task is to handle a new type of stock item that is *Conjured*. Seems simple, until you look inside the main code base and it is a single large complex function with deep nesting…

## Characterization tests

A strategy for dealing with systems like this is to use Characterization Tests;

> “In computer programming, a characterization test (also known as Golden Master Testing[1]) is a means to describe (characterize) the actual behavior of an existing piece of software, and therefore protect existing behavior of legacy code against unintended changes via automated testing. This term was coined by Michael Feathers.[2]”

**Note**: Sometimes these are called Approval Tests

## Getting started
So what does this mean? Before refactoring and changing code we should capture its current behaviour, if it doesn’t have good automated tests.

There are many different languages that you can perform this exercise in the Gilded Rose repository. Pick your favourite. They all work in broadly the same way;

  * They have an *item* record class with *quality* and *sellIn* integer fields
  * They have a method that updates a list of items for the new *quality* and *sellIn* for the next day
  * Don’t change the *item* class or the signature of the update method
  * They have a basic unit test that doesn’t work
  * **Some** have a basic Approval Test that logs to the console the status of all the items each day for a 30 day run. It compares the output with a previous known run to validate they are the same. This can be used to validate that any changes you make have not introduced any change to the behaviour.

## So what next
  * If it doesn't already have an Approval Test - maybe you should write one.
    * They have a main method that logs the results of 30 days to the console. Maybe copy this output this into a file, and turn it into a test! So when the test runs, compare the test output with the original output. It the output has changed you've broken something!
  * Can you improve the update code to make it easier to understand and make changes to?
  * Can you make it handle Conjured items?
  * Do you need to add any additional unit tests?

**Note**: There are gaps in the requirements and (at least) one defect in the implementation. But where the specification differs from the code, it is the code that is correct. It has  been like that for years I have been told and no one has complained…



# Reference

Slides:

https://docs.google.com/presentation/d/1TTccuVTvTEvw1QnSnrReTU7VjZZi8BNlOZtqslPcO0Q
