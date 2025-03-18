Feature: MatchingEngine

A short summary of the feature

@MatchingEngine
Scenario: Verify supported product list
	Given Navigate to the Matching Engine Website
	When Navigate to the Repertoire Managment Module Page
	And Check the supported products under Additional Features
	Then Check the list of supported products displayed
	Then Verify 'Cue Sheet / AV Work' is available
	Then Verify 'Recording' is available
	Then Verify 'Bundle' is available
	Then Verify 'Advertisement' is available

