# 🗺️ ProjectFocusPilot Roadmap  
**Initial Generation:** CoPilot — September 15, 2025  

---

## 🚀 Phase 1: MVP — Motivational Quote Display  
**Goal:** Display a motivational quote from a free API in Avalonia UI and Blazor WebAssembly.

### ✅ Tasks

- [ ] Set up Avalonia UI project (desktop + mobile targets)  
- [ ] Research and select free motivational quote API (e.g., ZenQuotes, They Said So)  
- [ ] Create basic UI layout (quote display, refresh button)  
- [ ] Implement API call and display logic  
- [ ] Add basic error handling and logging  
- [ ] Write README with setup instructions and MVP scope  

### 🌐 Blazor WebAssembly Additions

- [ ] Scaffold Blazor WebAssembly project (`FocusPilot.WebDemo`)  
- [ ] Share quote logic via `FocusPilot.Core`  
- [ ] Build quote display component in Blazor  
- [ ] Configure GitHub Pages deployment  
- [ ] Add Live Demo section to README  

---

## 🧩 Phase 2: Core Assistant Modules (Local Use)  
**Goal:** Add modular features for personal productivity.

### 📝 Note-taking Module

- [ ] Short notes with timestamp  
- [ ] Save locally (e.g., SQLite or JSON)  

### 🧠 Brain Dump Module

- [ ] Freeform text input  
- [ ] “Minimal step to get started” field  
- [ ] Tagging or categorization  

### 🎯 Goal Tracker Module

- [ ] Track short, medium, long-term goals  
- [ ] Progress tracking UI  

### 📋 Task Assistant Module

- [ ] Daily/weekly task entry  
- [ ] Optional AI suggestion stub (placeholder for future)  

### 🌅 Morning Assistant Module

- [ ] Display motivational message  
- [ ] Show today’s goals/tasks  

---

## 📆 Phase 3: Calendar Integration  
**Goal:** Connect to Outlook and Google Calendar.

- [ ] Explore Microsoft Graph API for Outlook  
- [ ] Explore Google Calendar API  
- [ ] Implement OAuth2 authentication  
- [ ] Display upcoming events  
- [ ] Add event creation UI  

---

## 🧠 Phase 4: AI-Enhanced Features  
**Goal:** Add intelligent helpers for scheduling, prioritization, and email triage.

- [ ] AI scheduling assistant  
  - Suggest optimal time blocks  
  - Conflict detection  

- [ ] Email scanner module  
  - Parse subject lines  
  - Flag urgency/importance  

- [ ] “What I’m struggling with” tracker  
  - Daily input  
  - Optional AI reflection or suggestion  

- [ ] Voice input/output support  
  - Explore Avalonia + speech libraries (e.g., System.Speech, Azure Speech SDK)  

---

## 📌 Phase 1 Roadmap — Motivational Quote Display  

### Milestone: Quote Display MVP  
- **Description:** Build core functionality to display motivational quotes on the UI  
- **Due Date:** 2025-09-30  
- **Goals:**  
  * Display random quote on launch  
  * Refresh quote every hour  
  * Ensure responsive layout  
- **Linked Issues:**  
  * #12 [UI] Quote rendering  
  * #15 [Logic] Quote rotation  

---

### Milestone: Quote Source Integration  
- **Description:** Integrate external quote API and local fallback  
- **Due Date:** 2025-10-07  
- **Goals:**  
  * Connect to public quote API  
  * Implement local cache fallback  
  * Add error handling for API failures  
- **Linked Issues:**  
  * #18 [API] External quote source  
  * #21 [Fallback] Local quote cache  

---

### Milestone: User Preferences  
- **Description:** Allow users to customize quote categories and refresh interval  
- **Due Date:** 2025-10-14  
- **Goals:**  
  * Add settings UI for preferences  
  * Save preferences locally  
  * Apply preferences on startup  
- **Linked Issues:**  
  * #25 [Settings] Category selection  
  * #27 [Settings] Interval config  

---

### Milestone: Live Demo Integration  
- **Description:** Build a Blazor WebAssembly demo for GitHub Pages  
- **Due Date:** 2025-10-21  
- **Goals:**  
  * Scaffold Blazor WebAssembly project  
  * Share logic via `FocusPilot.Core`  
  * Build quote display component  
  * Configure GitHub Pages deployment  
  * Link demo from README  
- **Linked Issues:**  
  * #30 [Blazor] Project scaffold  
  * #31 [Blazor] Quote component  
  * #32 [Core] Logic refactor  
  * #33 [CI/CD] GitHub Pages setup  
  * #34 [Docs] Live demo link  
