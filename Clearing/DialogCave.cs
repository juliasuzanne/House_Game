using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCave : DialogTemplate
{

    protected override IEnumerator MoveThroughDialogue()
    {
        SetupConversation();
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _panel.SetActive(true);

        // A 0 BUTTON PRESSED
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();
        if (waitForButton.PressedButton == AButton)
        {
            PlayerSaySomething(0);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            NPCTalkThenPanel(1, 1, 1);
            yield return waitForButton.Reset();

            // A 1 BUTTON PRESSED
            if (waitForButton.PressedButton == AButton)
            {
                PlayerSaySomething(1);                         //SET PLAYER TEXT FROM ARRAY
                yield return new WaitForSeconds(2.0f);
                EndConversation();
                yield break;

            }
            // B 1 BUTTON PRESSED
            else
            {
                PlayerSaySomething(2);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NPCTalkThenPanel(3, 3, 3);
                waitForButton = new WaitForUIButtons(AButton, BButton);
                yield return waitForButton.Reset();

                if (waitForButton.PressedButton == AButton)
                {
                    PlayerSaySomething(3);                       //SET PLAYER TEXT FROM ARRAY
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                    NPCTalking();
                    _NPCText.text = NPCText_string[2];
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                    yield break;

                }
                else
                {

                    PlayerSaySomething(4);
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    NPCTalking();
                    _NPCText.text = NPCText_string[4];
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                    yield break;
                }

            }

        }
    }
}
