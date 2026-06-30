# Contributing to ReplyFlow

Thanks for your interest in contributing! This document explains how to prepare contributions (issues and pull requests), the project's PR style guidelines, and testing requirements.

## Table of contents

- How to contribute
- Pull request (PR) style
- Commit messages
- Testing requirements
- Code style and formatting
- CI and checks
- Review checklist

## How to contribute

1. Search existing issues or open a new issue to discuss significant changes or features before starting work.
2. Fork the repository and create a branch for your change. Use a descriptive branch name, e.g., `feat/register-phone-validation` or `fix/forgot-password-expiry`.
3. Make small, focused changes per PR. One logical change per PR makes review faster.
4. Ensure all tests pass locally and that you add tests for new features and bug fixes.
5. Push your branch to your fork and open a pull request against the `master` branch of this repository.

## Pull request (PR) style

- Title: Use a short, descriptive title. Prefix with a conventional tag when appropriate, e.g., `feat:`, `fix:`, `chore:`, `docs:`.
  - Examples: `feat: add SMS provider abstraction`, `fix: handle null phone numbers in RegisterHandler`
- Description: Explain what the change does, why it is needed, and any important implementation details. If the PR fixes an issue, reference it with `Fixes #<issue-number>`.
- Scope: Keep PRs small and limited to a single concern.
- Branches: Target the `master` branch (or the default branch used by the repository). If your change depends on another PR, explain the dependency in the description.

## Commit messages

- Use clear, imperative, present-tense messages (e.g., `Add reset code expiry validation`).
- Keep the subject line under ~72 characters when possible. Add body paragraphs for additional details.
- If following Conventional Commits helps your workflow, feel free to use them, but they are not strictly required.

## Testing requirements

- All new features and bug fixes should include unit tests where applicable.
- Tests should be small, deterministic, and fast. Prefer testing handlers, factories, and domain logic in isolation.
- If your change affects database code, use an in-memory or test database setup in tests (e.g., `Sqlite` in-memory) rather than relying on a developer's local DB.
- Run tests locally before opening a PR:

```bash
# From the repository root
dotnet test
```

- Ensure any new tests pass on CI.

## Code style and formatting

- Follow the repository's existing C# style and conventions. If using an editor like VS Code or Rider, enable formatting on save to keep changes consistent.
- Use `dotnet format` or your editor's formatter to format code before committing.
- Keep method and class names descriptive and prefer small methods with a single responsibility.

## CI and checks

- The repository may run CI checks (build, tests, linters). Your PR should pass all required checks before it can be merged.
- If a CI failure is unrelated to your change, explain this in the PR and consider re-running CI after updates.

## Review checklist (maintainers and contributors)

- [ ] Builds successfully
- [ ] Tests pass (local + CI)
- [ ] No breaking changes without clear justification
- [ ] Coding conventions followed and code formatted
- [ ] Documentation updated (README, comments) if applicable
- [ ] Small, focused PR description and linked issues (if any)

Thank you for helping improve ReplyFlow — we appreciate your contributions!
