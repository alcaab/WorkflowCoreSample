# WorkflowCoreSample

The example is based on the following Workflow

* Tasks will be created once the contract is pre-entered 
* The first task is to upload the contract document 
* The second task is to check the contract 
* The second task will become active as soon as the first task is completed 
* Once both tasks are completed and the contract is approved, the contract enters the status "Active" 
* If both tasks are completed and the contract is rejected, the contract will enter the status "Vorerfasst"



### Usage:
1.	Clone this repository
2.	Open the solution in Rider or VS
3.	Run Contract.Api Project
4.	Browse to http://localhost: 7512 (swagger will be displayed)
5.	On the Events controller expand the actions a go to */api/Events/StartWorkflow*
click on *Try it out*, copy and paste this json: 
*{"id": "493ac96a-af21-4c4f-a0b3-096c37d6fa99","contractState": 0}*
 in the request body input and finally click on the execute button.

6.	Go to */api/Events/UploadPdf/{eventKey}*  action click on *Try it out* button
a) In the EventKey parameter copy and paste this guid :*493ac96a-af21-4c4f-a0b3-096c37d6fa99*
b) Copy and paste this empty json on the request body input :*{}*
c) Click on the execute button.

7.	Go to */api/Events/CheckContract/{eventKey}* action click on *Try it out* button
a) In the EventKey parameter copy and paste this guid :*493ac96a-af21-4c4f-a0b3-096c37d6fa99*
b) Copy and paste this empty json on the request body input : *{"approvalState": 1}*
c) Click on the execute button.



### Explanation
The **StartWorkflow** action starts the flow and represents the contract sent from the client with Preregistered status. Once flow started the following happens:
a)	A row is added to *WorkflowDocument* table. This row contains the data necessary to identify the document (Contract) during its passage through the flow. Without the need to contaminate the contract entity with information that does not contribute to the contract itself.

b)	**PreregisterContractStep** is executed and add a row to *DocumentTaskHistory* table (Table that keeps a chronological record of all the events of a document during its passage through the flow).

c)	The **UploadContractPdf** event is started and executes the UploadContractPdfStep task. This task adds a new row to DocumentTaskHistory table.



The  **UploadPdf** action triggers the event that tells the flow that the document has been uploaded. Once task is complete the following happens:
a)	The **UploadPdf** event is completed and adds a new row to *DocumentTaskHistory* table.

b)	The **ReviewContract** event is started and executes the *ReviewContractStep* task. This task adds a new row to *DocumentTaskHistory* table.



The  **CheckContract** action triggers the event that tells the flow that the document has been approved or rejected. Once task is complete the following happens:
a)	Depending on the value received in the *ApprovalState* property of the contract, one of the following tasks will be executed:
* When is Approved (1): **ApproveContractStep** is executed and perform all needed actions to change the status of the contract to "Aktiv".
* When is Rejected (2): **RejectContractStep** is executed and perform all needed actions to change the status of the contract to " Vorerfasst"

a)	A new row is added to *DocumentTaskHistory* table.

Workflow ends.
