# Silent Tower
스마일게이트 챌린지 시즌2, 침묵의 탑

# Classes

## GameManager
게임 전체를 관리하는 클래스. 현재는 게임 초기화(Initialize)만 존재하지만, 글로벌하게 사용하는 기능이 필요할 경우 여기에 추가.

## GameDataManager : ScriptableObject
게임 데이터를 관리하는 클래스. 스크립터블 오브젝트로 유니티에서 데이터를 관리하여 게임에서 사용.

## GameDataManager.Instance.saveData
저장되어야 하는 데이터 관리. json으로 PlayerPrefs에 Sereialize하여 저장.

## IntroScene,MapScene,IngameScene
각 씬의 메인 코드

## CharacterData
캐릭터 데이터. 인덱스는 유니크해야 하고, 캐릭터 직업과 이미지인덱스가 포함되어 있음. 캐릭터가 가지고 있는 복수의 스킬 인덱스도 존재함.

## SkillData
스킬 데이터. 스킬타입을 Enum으로 선언해놓았고 스킬의 효과는 상속받아 구현해야 할 것임.

## ScreenLock.Lock(), Unlock()
유저의 입력을 막음.
