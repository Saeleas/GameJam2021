using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsFoundController : MonoBehaviour
{
    private List<FriendAIController> friends = new List<FriendAIController>();

    public void AddFriend(FriendAIController friend)
    {
        if (!friends.Contains(friend))
        {
            if (friends.Count > 0 && !friends[0].gameObject.Equals(friend.gameObject))
            {
                friend.player = friends[friends.Count - 1].gameObject;
            }
            friends.Add(friend);
            friends[0].distance = new Vector2(.75f, .75f);
        }
    }
}
