# 우주방범대 1.3

<h5>우주방범대 1.3은 2D의 리듬·슈팅 게임이다.<br>
우주선을 타고 우주를 순찰하는 플레이어는 각 스테이지의 적을 향해 공격을 해야 한다.<br>
플레이어가 리듬에 맞추어 키를 누를 때만 슈팅 공격을 할 수 있으며, 스페이스 바와 방향키를 사용한다.</h5>
<h6>우주방범대 1.3의 1은 왼쪽에서 하나의, 3은 오른쪽에서 세 개의 손가락을 이용하기 때문에 붙여졌다.</h6><br>

<div>
<img src="https://user-images.githubusercontent.com/85846475/205579705-4efd9d97-fb3f-4688-a7a2-15735a851e2e.gif" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205579755-cd8c1e3b-0cb8-489a-a110-4d4ad1f837fd.gif" height="200"><br>
<img src="https://user-images.githubusercontent.com/85846475/205579809-495d792f-7559-4f2e-8e8e-0f2690136cd4.gif" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205581039-eb6de186-68d8-4c23-91fa-bf9d7d752658.gif" height="200">
</div>
<h6><a href="https://github.com/SE0NA/2DGameProject/blob/main/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%20play_video.mp4">전체 시현 영상</a></h6>
<br><br>

***
<h5>
1. 프로젝트명: 2DGameProject - 우주방범대 1.3 <br>
2. 개인 프로젝트
</h5>

***
### 게임 내용

#### 1. 게임 시작 화면
<div>
<img src="https://user-images.githubusercontent.com/85846475/205581911-f73b28c4-1103-4b4e-a3a0-4851a6bfc5eb.png" height="280">
<img src="https://user-images.githubusercontent.com/85846475/205582827-8f482e6e-7cdb-4321-bc4d-6173d753acd0.png" height="280"><br>
<h6>게임을 실행했을 때의 화면이다.<br>
설정을 통해 사운드 크기를 조절하거나 데이터(PlayerPrefs)를 초기화할 수 있다.</h6>
</div>
<br><br>

#### 2. 게임 메뉴
<div><h6>
<img src="https://user-images.githubusercontent.com/85846475/205583449-e4b24476-d412-4e9c-8583-6581c7cd8add.png" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205583676-d3eb747f-f6bc-4701-9f88-50ca87a6a07f.png" height="200"><br>
화살표 버튼을 클릭하거나 키보드의 방향키로 플레이할 스테이지를 선택할 수 있다. 스페이스 바로 선택한 게임을 시작한다<br>
스테이지의 대표 이미지와 음악의 정보, 최고 점수를 표시한다.</h6></div>
<div><h6>
<img src="https://user-images.githubusercontent.com/85846475/205585062-3e372c08-a6c4-45cd-86e8-fd54ef47d910.png" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205584751-1b3f4643-35c3-423e-949c-c7d0cfc77369.png" height="200"><br>
설정 메뉴를 통해 플레이어의 정보와 게임 설정을 할 수 있다.<br>
플레이어의 이름, 플레이한 스테이지 수, 총 합 점수를 확인할 수 있다. 게임에서의 노트 속도를 설정할 수 있다.</h6>
</div>
<br><br>

#### 4. 게임 플레이
<div><h6>
<img src="https://user-images.githubusercontent.com/85846475/205585737-56c862cc-333e-478e-bc3e-752d2e98e7a3.png" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205585844-537ce9cb-abde-4052-bddf-b3a3c4002794.png" height="200"><br>
각 스테이지는 Prefab으로 저장되어 선택한 스테이지를 불러오는 방식으로 실행된다.
</h6></div>

<div>
<h5> -1) 적의 공격 </h5>
<h6>
<img src="https://user-images.githubusercontent.com/85846475/205589511-4d64d094-9275-44d2-b6f8-ded52394d4b5.gif" width="150">
<img src="https://user-images.githubusercontent.com/85846475/205587905-6f664a08-995b-4f92-bb33-5e99459f4f83.png" width="150"><br>
적이 발사하는 오브젝트들이 플레이어 오브젝트에 맞으면 감점되며 플레이어 오브젝트에 맞는 효과를 확인할 수 있다.<br>
공격의 오브젝트는 여러 종류가 가능하며, 각 공격의 속도와 점수가 다르다. <br>공격의 생성 시과 그 종류는 txt파일에서 불러오도록 하였다.<br>
적 오브젝트에서 플레이어 오브젝트 방향으로 공격 오브젝트의 이동 방향을 설정하여, 플레이어 오브젝트를 향해 공격을 발사하도록 하였다.<br>
적은 좌우로 이동하며, 스테이지마다 적의 속도가 다르다.</h6>
</div>

<div>
<h5> -2) 플레이어의 공격 </h5>
<h6>
<img src="https://user-images.githubusercontent.com/85846475/205591716-fae7839f-b534-43d5-982c-a46a133a7b71.gif" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205592433-4c083a0f-64a0-4d3d-8e8c-d44bcf371eb7.gif" height="200">
<img src="https://user-images.githubusercontent.com/85846475/205590942-a3ef064c-4013-49ed-a18f-ef0cb313509e.gif" height="200"><br>
플레이어가 날라오는 노트의 박자에 맞춰 스페이스 바를 누르면 공격을 생성하여 직선으로 발사한다.<br>
스페이스 바를 누른 타이밍의 정확도에 따라 점수를 다르게 한다.<br>
공격은 적 오브젝트를 맞추거나, 적의 공격 오브젝트를 맞춰 제거할 수 있다. 적이 공격에 맞으면 공격의 정도에 따라 효과를 다르게 한다.<br></h6>
</div>

<div>
<h5> -3) 게임 결과 </h5>
<h6>
<img src="https://user-images.githubusercontent.com/85846475/205594780-2d0cbccd-5365-4ed5-973d-efb677552b92.gif" height="200"><br>
게임이 끝나면 결과 화면을 표시한다.<br>
게임의 점수는 스테이지 선택 화면과 설정의 총합 점수에서 확인할 수 있다.<br></h6>
</div>
<br><br>

***
### 주요 코드
<h6><ul>
<li><a href="https://github.com/SE0NA/2DGameProject/blob/main/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%201.3/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%201.3/Assets/Scripts/Stage/GameManager.cs">GameManager.cs</a></li>
<li><a href="https://github.com/SE0NA/2DGameProject/blob/main/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%201.3/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%201.3/Assets/Scripts/Stage/PlayerController.cs">PlayerController.cs</a></li>
<li><a href="https://github.com/SE0NA/2DGameProject/blob/main/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%201.3/%EC%9A%B0%EC%A3%BC%EB%B0%A9%EB%B2%94%EB%8C%80%201.3/Assets/Scripts/Stage/NoteManager.cs">NoteManager.cs</a></li>
</ul></h6>

***

#### 사용 에셋 
<h6><table>
<tr><td>폰트</td><td>둥근모꼴+Fixedsys</td></tr>
<tr><td>음향 효과</td><td>8 Bits Element – Game Sound Solution <br>8Bits Music Album – 051321 – GWriterStudio <br>Deep In Space - Breibarth</td></tr>
</table></h6>
<br>

#### 참고 자료
<h6><ul>
<li>[Youtube]케이디 - [유니티 강좌]-리듬게임</li>
<li>[Youtube]골드메탈 - 유니티 2D 종스크롤 슈팅 모바일[BE4]</li>
</ul></h6>
